using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.Data.Models;

public class Booking
{
	public Guid Id { get; set; }
	public HotellRoom Room { get; set; }
	public Person Person { get; set; }
}
