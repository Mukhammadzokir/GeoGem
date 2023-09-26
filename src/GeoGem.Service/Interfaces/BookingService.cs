using GeoGem.Service.DTOs.Bookings;

namespace GeoGem.Service.Interfaces;

public interface BookingService
{
    public Task<List<BookingForResultDto>> GetAllAsync();
    public Task<bool> RemoveAsync(long id);
    public Task<BookingForResultDto> GetByIdAsync(long id);
    public Task<BookingForResultDto> UpdateAsync(BookingForUpdateDto dto);
    public Task<BookingForResultDto> CreateAsync(BookingForCreationDto dto);
}
