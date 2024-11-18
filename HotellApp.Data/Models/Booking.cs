using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Data.Models;

public class Booking
{
	public Guid Id { get; set; }
	public Guid RoomId { get; set; }
	public Guid PersonId { get; set; }
	public DateTimeOffset StartDate { get; set; }
	public DateTimeOffset EndDate { get; set; }
	public decimal TotalPrice { get; set; }
	public HotellRoom Room { get; set; }
	public Person Person { get; set; }
}
