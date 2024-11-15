namespace HotellApp.Server.Models;

public class HotellRoom
{
	public Guid Id { get; set; }
	public int NumberOfBeds { get; set; }
	public decimal Price { get; set; }
	public string Description { get; set; }
}
