using HotellApp.Server.Commands;
using HotellApp.Server.Models;
using Microsoft.Identity.Client;

namespace HotellApp.Server.Services;

public class HotellManagementService : IHotellManagementService
{
	private readonly AddRoomToDatabase _addRoomToDatabase;
	private readonly GetAllRoomsFromDatabase _getAllRoomsFromDatabase;
	private readonly DeleteRoomFromDatabase _deleteRoomFromDatabase;
	public HotellManagementService(AddRoomToDatabase addRoomToDatabase, GetAllRoomsFromDatabase getAllRoomsFromDatabase, DeleteRoomFromDatabase deleteRoomFromDatabase)
	{
		_addRoomToDatabase = addRoomToDatabase;
		_getAllRoomsFromDatabase = getAllRoomsFromDatabase;
		_deleteRoomFromDatabase = deleteRoomFromDatabase;
	}

	public async Task AddRoom(HotellRoomDto room)
	{
		await _addRoomToDatabase.ExecuteAsync(room);
	}

	public async Task<IEnumerable<HotellRoomDto>> GetAllRooms()
	{
		return await _getAllRoomsFromDatabase.ExecuteAsync();
	}

	public async Task DeleteRoom(Guid id)
	{
		await _deleteRoomFromDatabase.ExecuteAsync(id);
	}
}
