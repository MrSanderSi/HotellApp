using HotellApp.Data;
using HotellApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HotellApp.Server.Commands;

public class GetAllRoomsFromDatabase
{
	private readonly HotellAppDbContext _db;

	public GetAllRoomsFromDatabase(HotellAppDbContext db)
	{
		_db = db;
	}

	public async Task<IEnumerable<HotellRoomDto>> ExecuteAsync()
	{
		return await _db.Rooms.Select(r => new HotellRoomDto
		{
			Id = r.Id,
			RoomNumber = r.RoomNumber,
			BedCount = r.BedCount,
			Price = r.Price,
			Description = r.Description
		}).ToListAsync();
	}
}
