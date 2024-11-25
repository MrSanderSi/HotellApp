using HotellApp.Data;
using HotellApp.Data.Models;
using HotellApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HotellApp.Server.Commands;

public class GetAllBookingsFromDatabase
{
    private readonly HotellAppDbContext _db;

    public GetAllBookingsFromDatabase(HotellAppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BookingDto>> ExecuteAsync(GetBookingsRequest request)
    {
        return await _db.Set<Booking>()
                .Include(x => x.Room)
                .Include(x => x.Person)
                .Where(x => x.StartDate >= request.StartDate && x.EndDate <= request.EndDate)
                .Select(x => new BookingDto
                {
                    Id = x.Id,
                    Name = x.Person.Name,
                    Email = x.Person.Email,
                    Phone = x.Person.Phone,
                    RoomNumber = x.Room.RoomNumber,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    RoomId = x.RoomId,
                    PersonId = x.PersonId
                }).ToListAsync();
    }
}
