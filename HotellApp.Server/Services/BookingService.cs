using HotellApp.Server.Commands;
using HotellApp.Server.Models;

namespace HotellApp.Server.Services;

public class BookingService : IBookingService
{
	private readonly GetAllVacantRoomsFromDatabase _getAllVacantRoomsFromDatabase;

    public BookingService(GetAllVacantRoomsFromDatabase getAllVacantRoomsFromDatabase)
    {
        _getAllVacantRoomsFromDatabase = getAllVacantRoomsFromDatabase;
	}

    public async Task<IEnumerable<HotellRoomDto>> GetAllVacantRooms(GetHotellRoomsRequest request)
	{
		return await _getAllVacantRoomsFromDatabase.ExecuteAsync(request);
	}
}
