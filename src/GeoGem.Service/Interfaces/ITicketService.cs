using GeoGem.Service.DTOs.Tickets;

namespace GeoGem.Service.Interfaces;

public interface ITicketService
{
    public Task<List<TicketForResultDto>> GetAllAsync();
    public Task<bool> RemoveAsync(long id);
    public Task<TicketForResultDto> GetByIdAsync(long id);
    public Task<TicketForResultDto> UpdateAsync(TicketForUpdateDto dto);
    public Task<TicketForResultDto> CreateAsync(TicketForCreationDto dto);
}
