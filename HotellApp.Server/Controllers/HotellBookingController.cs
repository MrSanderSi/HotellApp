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

	public HotellBookingController(ILogger<HotellBookingController> logger, IHotellManagementService hotellManagementService)
	{
		_logger = logger;
		_hotellManagementService = hotellManagementService;
	}

	[HttpGet("GetAllRooms")]
	public async Task<IEnumerable<HotellRoomDto>> GetAllRoomsAsync()
	{
		return await _hotellManagementService.GetAllRooms();
	}

	[HttpGet("GetVacantRooms")]
	public async Task<IEnumerable<HotellRoomDto>> GetVacantRoomsAsync([FromQuery] GetHotellRoomsRequest request)
	{
		// Assuming you would call a service method to get vacant rooms asynchronously
		return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new HotellRoomDto
		{
			Id = Guid.NewGuid(),
			BedCount = Random.Shared.Next(1, 3),
			Price = Random.Shared.Next(50, 120),
			Description = "Test Room"
		})
		.ToArray());
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
