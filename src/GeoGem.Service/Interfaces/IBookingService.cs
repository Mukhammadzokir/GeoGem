using GeoGem.Service.DTOs.Bookings;

namespace GeoGem.Service.Interfaces;

public interface IBookingService
{
    public Task<List<BookingForResultDto>> GetAllAsync();
    public Task<BookingForResultDto> CreateAsync(BookingForCreationDto dto);
}
