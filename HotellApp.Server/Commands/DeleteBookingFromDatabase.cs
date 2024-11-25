using HotellApp.Data;
using HotellApp.Server.Models;

namespace HotellApp.Server.Commands;

public class DeleteBookingFromDatabase
{
    private readonly HotellAppDbContext _dbContext;

    public DeleteBookingFromDatabase(HotellAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResult> ExecuteAsync(Guid bookingId)
    {
        var booking = await _dbContext.Bookings.FindAsync(bookingId);
        if (booking == null)
        {
            return ServiceResult.Failure("Booking not found");
        }

        if(booking.StartDate < DateTime.Now.AddDays(3))
        {
            return ServiceResult.Failure("Booking can't be deleted less than 72 hours before start date");
        }

        _dbContext.Bookings.Remove(booking);
        await _dbContext.SaveChangesAsync();
        return ServiceResult.SuccessResult();
    }
}
