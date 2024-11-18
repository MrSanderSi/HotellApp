namespace HotellApp.Server.Models;

public class GetBookingsRequest
{
	public DateTimeOffset StartDate { get; set; }
	public DateTimeOffset EndDate { get; set; }
}
