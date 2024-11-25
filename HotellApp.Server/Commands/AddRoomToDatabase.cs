using HotellApp.Data;
using HotellApp.Data.Models;
using HotellApp.Server.Models;

namespace HotellApp.Server.Commands;

public class AddRoomToDatabase
{
    private readonly HotellAppDbContext _db;

    public AddRoomToDatabase(HotellAppDbContext db)
    {
        _db = db;
    }

    public async Task ExecuteAsync(HotellRoomDto request)
    {
        HotellRoom room = new()
        {
            RoomNumber = request.RoomNumber,
            BedCount = request.BedCount,
            Price = request.Price,
            Description = request.Description
        };

        await _db.Rooms.AddAsync(room);
        await _db.SaveChangesAsync();
    }
}
