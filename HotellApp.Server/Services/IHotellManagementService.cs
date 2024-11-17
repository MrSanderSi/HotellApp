using HotellApp.Server.Models;
using System.Threading.Tasks;

namespace HotellApp.Server.Services
{
	public interface IHotellManagementService
	{
		Task AddRoom(HotellRoomDto room);

		Task DeleteRoom(Guid id);

		Task<IEnumerable<HotellRoomDto>> GetAllRooms();
	}
}
