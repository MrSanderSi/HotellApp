namespace HotellApp.Server.Models;

public class GetHotellRoomsRequest
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}
