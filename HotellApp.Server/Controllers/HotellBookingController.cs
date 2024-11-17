using HotellApp.Server.Models;
using HotellApp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotellApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class HotellBookingController : ControllerBase
{
	private readonly ILogger<HotellBookingController> _logger;
	private readonly IHotellManagementService _hotellManagementService;
	private readonly IBookingService _bookingService;

	public HotellBookingController(ILogger<HotellBookingController> logger, IHotellManagementService hotellManagementService, IBookingService bookingService)
	{
		_logger = logger;
		_hotellManagementService = hotellManagementService;
		_bookingService = bookingService;
	}

	[HttpGet("GetAllRooms")]
	public async Task<IEnumerable<HotellRoomDto>> GetAllRoomsAsync()
	{
		return await _hotellManagementService.GetAllRooms();
	}

	[HttpGet("GetVacantRooms")]
	public async Task<IEnumerable<HotellRoomDto>> GetVacantRoomsAsync([FromQuery] GetHotellRoomsRequest request)
	{
		return await _bookingService.GetAllVacantRooms(request);
	}

	[HttpPost("AddRoom")]
	public async Task<IActionResult> AddRoomAsync([FromBody] HotellRoomDto room)
	{
		await _hotellManagementService.AddRoom(room);
		return Ok();
	}

	[HttpDelete("DeleteRoom/{id}")]
	public async Task<IActionResult> DeleteRoomAsync(Guid id)
	{
		await _hotellManagementService.DeleteRoom(id);
		return Ok();
	}
}
