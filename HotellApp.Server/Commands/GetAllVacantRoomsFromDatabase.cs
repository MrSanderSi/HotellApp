using HotellApp.Data;
using HotellApp.Data.Models;
using HotellApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HotellApp.Server.Commands;

public class GetAllVacantRoomsFromDatabase
{
    private readonly HotellAppDbContext _db;

    public GetAllVacantRoomsFromDatabase(HotellAppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<HotellRoomDto>> ExecuteAsync(GetHotellRoomsRequest request)
    {
        return await _db.Set<HotellRoom>()
            .GroupJoin(
                _db.Set<Booking>()
                    .Where(booking => booking.StartDate < request.EndDate && booking.EndDate > request.StartDate),
                room => room.Id,
                booking => booking.RoomId,
                (room, bookings) => new { room, bookings }
            )
            .Where(roomWithBookings => !roomWithBookings.bookings.Any())
            .Select(roomWithBookings => new HotellRoomDto
            {
                Id = roomWithBookings.room.Id,
                RoomNumber = roomWithBookings.room.RoomNumber,
                BedCount = roomWithBookings.room.BedCount,
                Price = roomWithBookings.room.Price,
                Description = roomWithBookings.room.Description
            })
            .ToListAsync();
    }
}
