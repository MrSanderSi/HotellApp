namespace HotellApp.Server.Models;

public class HotellRoomDto
{
    public Guid Id { get; set; }
    public int RoomNumber { get; set; }
    public int BedCount { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}
