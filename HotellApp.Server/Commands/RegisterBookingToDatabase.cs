using HotellApp.Data;
using HotellApp.Data.Models;
using HotellApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HotellApp.Server.Commands;

public class RegisterBookingToDatabase
{
	private readonly HotellAppDbContext _dbContext;

	public RegisterBookingToDatabase(HotellAppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<ServiceResult> ExecuteAsync(BookingDto request)
	{
		var room = await _dbContext.Set<HotellRoom>().Where(x => x.Id == request.RoomId).FirstOrDefaultAsync();

		if (room == null)
		{
			return ServiceResult.Failure("Booking not found");
		}

		var dayCount = (int)(request.EndDate - request.StartDate).TotalDays;
		var person = new Person
		{
			Id = Guid.NewGuid(),
			IdCode = request.IdCode,
			Name = request.Name,
			Email = request.Email,
			Phone = request.Phone
		};

		var booking = new Booking
		{
			StartDate = request.StartDate,
			EndDate = request.EndDate,
			RoomId = request.RoomId,
			PersonId = person.Id,
			TotalPrice = room.Price * dayCount
		};

		_dbContext.People.Add(person);
		_dbContext.Bookings.Add(booking);
		await _dbContext.SaveChangesAsync();

		return ServiceResult.SuccessResult();
	}
}
