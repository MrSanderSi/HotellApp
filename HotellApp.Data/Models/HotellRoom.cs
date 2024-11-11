using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Data.Models;

public class HotellRoom
{
	public Guid Id { get; set; }
	public int BedCount { get; set; }
	public decimal Price { get; set; }
	public IEnumerable<Booking> Bookings { get; set; }
}
