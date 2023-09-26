using GeoGem.Data.IRepositories;
using GeoGem.Data.Repositories;
using GeoGem.Domain.Entities;
using GeoGem.Service.DTOs.Tickets;
using GeoGem.Service.DTOs.Users;
using GeoGem.Service.Exceptions;
using GeoGem.Service.Interfaces;

namespace GeoGem.Service.Services;

public class TicketService : ITicketService
{
    private long _id;
    private readonly IRepository<Ticket> ticketRepository = new Repository<Ticket>();
    public async Task<TicketForResultDto> CreateAsync(TicketForCreationDto dto)
    {
        var ticket = (await ticketRepository.SelectAllAsync())
            .FirstOrDefault(t => t.FlightDuration == dto.FlightDuration && t.Price == dto.Price);
        if (ticket != null)
            throw new GeoGemException(409, "Ticket is already exist");

        await GenerateIdAsync();

        var ticketForCreate = new Ticket()
        {
            Id = _id,
            LandMarkId = dto.LandMarkId,
            FlightDuration = dto.FlightDuration,
            Price = dto.Price,
            CreatedAt = DateTime.UtcNow,
        };

        await ticketRepository.InsertAsync(ticketForCreate);

        var result = new TicketForResultDto()
        {
            Id = _id,
            LandMarkId = dto.LandMarkId,
            FlightDuration = dto.FlightDuration,
            Price = dto.Price,
        };

        return result;
    }

    public Task<List<TicketForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TicketForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<TicketForResultDto> UpdateAsync(TicketForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task GenerateIdAsync()
    {
        var tickets = await ticketRepository.SelectAllAsync();
        if (tickets.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var ticket = tickets[tickets.Count() - 1];
            this._id = ++ticket.Id;
        }
    }
}
