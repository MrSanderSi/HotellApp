using HotellApp.Data;
using HotellApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotellApp.Server.Commands;

public class DeleteRoomFromDatabase
{
    private readonly HotellAppDbContext _db;

    public DeleteRoomFromDatabase(HotellAppDbContext db)
    {
        _db = db;
    }

    public async Task ExecuteAsync(Guid id)
    {
        var room = await _db.Set<HotellRoom>()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (room != null)
        {

            _db.Remove(room);
            await _db.SaveChangesAsync();
        }

        await Task.CompletedTask;
    }
}
