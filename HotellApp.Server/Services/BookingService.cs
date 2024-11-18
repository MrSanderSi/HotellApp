using HotellApp.Server.Commands;
using HotellApp.Server.Models;
using Microsoft.Identity.Client;

namespace HotellApp.Server.Services;

public class BookingService : IBookingService
{
	private readonly GetAllVacantRoomsFromDatabase _getAllVacantRoomsFromDatabase;
	private readonly RegisterBookingToDatabase _registerBookingToDatabase;
	private readonly GetAllBookingsFromDatabase _getAllBookingsFromDatabase;
	private readonly DeleteBookingFromDatabase _deleteBookingFromDatabase;

	public BookingService(
		GetAllVacantRoomsFromDatabase getAllVacantRoomsFromDatabase,
		RegisterBookingToDatabase registerBookingToDatabase,
		GetAllBookingsFromDatabase getAllBookingsFromDatabase,
		DeleteBookingFromDatabase deleteBookingFromDatabase)
	{
		_getAllVacantRoomsFromDatabase = getAllVacantRoomsFromDatabase;
		_registerBookingToDatabase = registerBookingToDatabase;
		_getAllBookingsFromDatabase = getAllBookingsFromDatabase;
		_deleteBookingFromDatabase = deleteBookingFromDatabase;
	}

	public async Task<ServiceResult<IEnumerable<HotellRoomDto>>> GetAllVacantRooms(GetHotellRoomsRequest request)
	{
		if (request == null || request.StartDate == default || request.EndDate == default)
		{
			return ServiceResult<IEnumerable<HotellRoomDto>>.Failure("Invalid request data.");
		}

		var rooms = await _getAllVacantRoomsFromDatabase.ExecuteAsync(request);

		return ServiceResult<IEnumerable<HotellRoomDto>>.SuccessResult(rooms);
	}

	public async Task<ServiceResult> RegisterBooking(BookingDto request)
	{
		if (request == null || request.RoomId == Guid.Empty || request.StartDate == default || request.EndDate == default)
		{
			return ServiceResult.Failure("Invalid booking data.");
		}

		await _registerBookingToDatabase.ExecuteAsync(request);

		return ServiceResult.SuccessResult();
	}

	public async Task<ServiceResult<IEnumerable<BookingDto>>> GetBookingsAsync(GetBookingsRequest request)
	{
		if(request == null || request.StartDate == default || request.EndDate == default)
		{
			return ServiceResult<IEnumerable<BookingDto>>.Failure("Invalid date range.");
		}

		var bookings = await _getAllBookingsFromDatabase.ExecuteAsync(request);

		return ServiceResult<IEnumerable<BookingDto>>.SuccessResult(bookings);
	}

	public async Task<ServiceResult> DeleteBookingAsync(DeleteBookingRequest request)
	{
		if(request == null)
		{
			return ServiceResult.Failure("Invalid booking reference");
		}

		return await _deleteBookingFromDatabase.ExecuteAsync(request.Id);
	}
}
