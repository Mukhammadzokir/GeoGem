using GeoGem.Data.IRepositories;
using GeoGem.Data.Repositories;
using GeoGem.Domain.Entities;
using GeoGem.Service.DTOs.Bookings;
using GeoGem.Service.Interfaces;

namespace GeoGem.Service.Services;

public class BookingService : IBookingService
{
    private long _id;
    private readonly IRepository<Booking> bookingRepository = new Repository<Booking>();
    public async Task<BookingForResultDto> CreateAsync(BookingForCreationDto dto)
    {
        await GenerateIdAsync();

        var bookingForCraete = new Booking()
        {
            Id = _id,
            UserId = dto.UserId,
            LandMarkId = dto.LandMarkId,
            TicketId = dto.TicketId,
            HotelId = dto.HotelId,
            CreatedAt = DateTime.UtcNow,
        };

        await bookingRepository.InsertAsync(bookingForCraete);

        var result = new BookingForResultDto()
        {
            Id = _id,
            UserId = dto.UserId,
            LandMarkId = dto.LandMarkId,
            TicketId = dto.TicketId,
            HotelId = dto.HotelId,
        };

        return result;
    }

    public async Task<List<BookingForResultDto>> GetAllAsync()
    {
        var bookings = await bookingRepository.SelectAllAsync();
        var mappedBookings = new List<BookingForResultDto>();

        foreach (var booking in bookings)
        {
            var item = new BookingForResultDto()
            {
                Id = booking.Id,
                UserId = booking.UserId,
                LandMarkId = booking.LandMarkId,
                TicketId = booking.TicketId,
                HotelId = booking.HotelId,
            };
            mappedBookings.Add(item);
        }
        return mappedBookings;
    }

    public async Task GenerateIdAsync()
    {
        var bookings = await bookingRepository.SelectAllAsync();
        if (bookings.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var booking = bookings[bookings.Count() - 1];
            this._id = ++booking.Id;
        }
    }
}
