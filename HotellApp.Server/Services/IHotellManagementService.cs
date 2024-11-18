using HotellApp.Server.Models;
using System.Threading.Tasks;

namespace HotellApp.Server.Services;

public interface IHotellManagementService
{
	/// <summary>
	/// Adds a new room to the hotel database.
	/// </summary>
	Task<ServiceResult> AddRoom(HotellRoomDto room);

	/// <summary>
	/// Deletes a room from the hotel database.
	/// </summary>
	Task<ServiceResult> DeleteRoom(Guid id);

	/// <summary>
	/// Gets all rooms from the hotel database.
	/// </summary>
	Task<ServiceResult<IEnumerable<HotellRoomDto>>> GetAllRooms();
}
