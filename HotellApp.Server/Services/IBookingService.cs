using HotellApp.Server.Models;

namespace HotellApp.Server.Services;

public interface IBookingService
{
	Task<IEnumerable<HotellRoomDto>> GetAllVacantRooms(GetHotellRoomsRequest request);
}