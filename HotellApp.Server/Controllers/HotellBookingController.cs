using HotellApp.Server.Models;
using HotellApp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotellApp.Server.Controllers;

[ApiController]
[Route("api/v1/hotellbooking")]
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

	[HttpGet("rooms")]
	public async Task<IActionResult> GetAllRoomsAsync()
	{
		var result = await _hotellManagementService.GetAllRooms();

		if (result.Success)
		{
			return Ok(result.Data);
		}

		_logger.LogError(result.ErrorMessage);
		return StatusCode(500, result.ErrorMessage);
	}

	[HttpGet("rooms/vacant")]
	public async Task<IActionResult> GetVacantRoomsAsync([FromQuery] GetHotellRoomsRequest request)
	{
		var result = await _bookingService.GetAllVacantRooms(request);

		if (result.Success)
		{
			return Ok(result.Data);
		}

		_logger.LogError(result.ErrorMessage);
		return BadRequest(result.ErrorMessage);
	}

	[HttpPost("rooms")]
	public async Task<IActionResult> AddRoomAsync([FromBody] HotellRoomDto room)
	{
		var result = await _hotellManagementService.AddRoom(room);

		if (result.Success)
		{
			return Ok(result);
		}

		_logger.LogError(result.ErrorMessage);
		return BadRequest(result.ErrorMessage);
	}

	[HttpDelete("rooms/{id}")]
	public async Task<IActionResult> DeleteRoomAsync(Guid id)
	{
		var result = await _hotellManagementService.DeleteRoom(id);

		if (result.Success)
		{
			return NoContent();
		}

		_logger.LogError(result.ErrorMessage);
		return BadRequest(result.ErrorMessage);
	}

	[HttpPost("bookings")]
	public async Task<IActionResult> RegisterBookingAsync([FromBody] BookingDto request)
	{
		var result = await _bookingService.RegisterBooking(request);

		if (result.Success)
		{
			return Ok(result);
		}

		_logger.LogError(result.ErrorMessage);
		return BadRequest(result.ErrorMessage);
	}

	[HttpGet("bookings")]
	public async Task<IActionResult> GetBookingsAsync(DateTimeOffset startDate, DateTimeOffset endDate)
	{
		var request = new GetBookingsRequest() { StartDate = startDate, EndDate = endDate };
		var result = await _bookingService.GetBookingsAsync(request);

		if (result.Success)
		{
			return Ok(result.Data);
		}

		_logger.LogError(result.ErrorMessage);
		return BadRequest(result.ErrorMessage);
	}

	[HttpDelete("bookings/{id}")]
	public async Task<ServiceResult> CancelBookingAsync(Guid id)
	{
		if (id == Guid.Empty)
		{
			return ServiceResult.Failure("Invalid booking ID.");
		}

		DeleteBookingRequest request = new() { Id = id };

		return await _bookingService.DeleteBookingAsync(request);
	}
}
