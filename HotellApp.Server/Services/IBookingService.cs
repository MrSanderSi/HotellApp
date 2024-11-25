using HotellApp.Server.Models;

namespace HotellApp.Server.Services;

public interface IBookingService
{
    /// <summary>
    /// Gets all vacant rooms within the given date range.
    /// </summary>
    Task<ServiceResult<IEnumerable<HotellRoomDto>>> GetAllVacantRooms(GetHotellRoomsRequest request);

    /// <summary>
    /// Registers a booking of a single romm with a single person with a given date range.
    /// </summary>
    Task<ServiceResult> RegisterBooking(BookingDto request);

    /// <summary>
    /// Get all bookings within the given date range.
    /// </summary>
    Task<ServiceResult<IEnumerable<BookingDto>>> GetBookingsAsync(GetBookingsRequest request);

    /// <summary>
    /// Delete given booking based on Id.
    /// </summary>
    Task<ServiceResult> DeleteBookingAsync(DeleteBookingRequest request);
}