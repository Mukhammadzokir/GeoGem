using GeoGem.Data.IRepositories;
using GeoGem.Data.Repositories;
using GeoGem.Domain.Entities;
using GeoGem.Service.DTOs.Tickets;
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

    public async Task<List<TicketForResultDto>> GetAllAsync()
    {
        var tickets = await ticketRepository.SelectAllAsync();
        var mappedTickets = new List<TicketForResultDto>();

        foreach (var ticket in tickets)
        {
            var item = new TicketForResultDto()
            {
                Id = ticket.Id,
                LandMarkId= ticket.LandMarkId,
                FlightDuration = ticket.FlightDuration,
                Price = ticket.Price,
            };
            mappedTickets.Add(item);
        }
        return mappedTickets;
    }

    public async Task<TicketForResultDto> GetByIdAsync(long id)
    {
        var ticket = await ticketRepository.SelectByIdAsync(id);
        if (ticket == null)
            throw new GeoGemException(404, "Ticket is not found");

        var result = new TicketForResultDto()
        {
            Id = ticket.Id,
            LandMarkId = ticket.LandMarkId,
            FlightDuration = ticket.FlightDuration,
            Price = ticket.Price,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var ticket = await ticketRepository.SelectByIdAsync(id);
        if (ticket == null)
            throw new GeoGemException(404, "Ticket is not found");

        await ticketRepository.DeleteAsync(id);

        return true;
    }

    public async Task<TicketForResultDto> UpdateAsync(TicketForUpdateDto dto)
    {
        var ticket = await ticketRepository.SelectByIdAsync(dto.Id);
        if (ticket == null)
            throw new GeoGemException(404, "Ticket is not found");

        var mappedTicket = new Ticket()
        {
            Id = dto.Id,
            LandMarkId = dto.LandMarkId,
            FlightDuration = dto.FlightDuration,
            Price = dto.Price,
            UpdatedAt = DateTime.UtcNow
        };

        await ticketRepository.UpdateAsync(mappedTicket);

        var result = new TicketForResultDto()
        {
            Id = mappedTicket.Id,
            LandMarkId = mappedTicket.LandMarkId,
            FlightDuration = mappedTicket.FlightDuration,
            Price = mappedTicket.Price,
        };

        return result;
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
