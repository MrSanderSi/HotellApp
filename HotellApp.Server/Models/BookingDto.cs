namespace HotellApp.Server.Models;

public class BookingDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int RoomNumber { get; set; }
    public long IdCode { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public Guid RoomId { get; set; }
    public Guid? PersonId { get; set; }
}
