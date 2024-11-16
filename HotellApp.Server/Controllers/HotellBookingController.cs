using HotellApp.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotellApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class HotellBookingController : ControllerBase
{
	private readonly ILogger<HotellBookingController> _logger;

	public HotellBookingController(ILogger<HotellBookingController> logger)
	{
		_logger = logger;
	}

	[HttpGet("GetVacantRooms")]
	public IEnumerable<HotellRoom> GetVacantRooms([FromQuery] GetHotellRoomsRequest request)
	{
		return Enumerable.Range(1, 5).Select(index => new HotellRoom
		{
			Id = Guid.NewGuid(),
			NumberOfBeds = Random.Shared.Next(1, 3),
			Price = Random.Shared.Next(50, 120),
			Description = "Test Room"
		})
		.ToArray();
	}
}
