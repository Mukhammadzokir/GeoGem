using GeoGem.Service.DTOs.Hotels;

namespace GeoGem.Service.Interfaces;

public interface IHotelService
{
    public Task<List<HotelForResultDto>> GetAllAsync();
    public Task<bool> RemoveAsync(long id);
    public Task<HotelForResultDto> GetByIdAsync(long id);
    public Task<HotelForResultDto> UpdateAsync(HotelForUpdateDto dto);
    public Task<HotelForResultDto> CreateAsync(HotelForCreationDto dto);
}
