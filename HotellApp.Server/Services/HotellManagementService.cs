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

    public async Task<ServiceResult> AddRoom(HotellRoomDto room)
    {
        if (room == null)
        {
            return ServiceResult.Failure("Room data is required.");
        }

        await _addRoomToDatabase.ExecuteAsync(room);

        return ServiceResult.SuccessResult();
    }

    public async Task<ServiceResult<IEnumerable<HotellRoomDto>>> GetAllRooms()
    {
        return ServiceResult<IEnumerable<HotellRoomDto>>.SuccessResult(await _getAllRoomsFromDatabase.ExecuteAsync());
    }

    public async Task<ServiceResult> DeleteRoom(Guid id)
    {
        if (id == Guid.Empty)
        {
            return ServiceResult.Failure("Invalid room ID.");
        }

        await _deleteRoomFromDatabase.ExecuteAsync(id);

        return ServiceResult.SuccessResult();
    }
}
