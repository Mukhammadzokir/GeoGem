using GeoGem.Data.IRepositories;
using GeoGem.Data.Repositories;
using GeoGem.Domain.Entities;
using GeoGem.Service.DTOs.Hotels;
using GeoGem.Service.DTOs.Tickets;
using GeoGem.Service.Exceptions;
using GeoGem.Service.Interfaces;
using NuGet.Protocol.Core.Types;

namespace GeoGem.Service.Services;

public class HotelService : IHotelService
{
    private long _id;
    private readonly IRepository<Hotel> hotelRepository = new Repository<Hotel>();
    public async Task<HotelForResultDto> CreateAsync(HotelForCreationDto dto)
    {
        var hotel = (await hotelRepository.SelectAllAsync())
            .FirstOrDefault(h => h.Name == dto.Name && h.Price == dto.Price);
        if (hotel != null)
            throw new GeoGemException(409, "Hotel is already exist");

        await GenerateIdAsync();

        var hotelForCreate = new Hotel()
        {
            Id = _id,
            LandMarkId = dto.LandMarkId,
            Name = dto.Name,
            Price = dto.Price,
            NumberOfRoom = dto.NumberOfRoom,
            CreatedAt = DateTime.UtcNow,
        };

        await hotelRepository.InsertAsync(hotelForCreate);

        var result = new HotelForResultDto()
        {
            Id = _id,
            LandMarkId = dto.LandMarkId,
            Name = dto.Name,
            Price = dto.Price,
            NumberOfRoom = dto.NumberOfRoom,
        };

        return result;
    }

    public async Task<List<HotelForResultDto>> GetAllAsync()
    {
        var hotels = await hotelRepository.SelectAllAsync();
        var mappedHotels = new List<HotelForResultDto>();

        foreach (var hotel in hotels)
        {
            var item = new HotelForResultDto()
            {
                Id = hotel.Id,
                LandMarkId = hotel.LandMarkId,
                Name = hotel.Name,
                Price = hotel.Price,
                NumberOfRoom = hotel.NumberOfRoom,
            };
            mappedHotels.Add(item);
        }
        return mappedHotels;
    }

    public async Task<HotelForResultDto> GetByIdAsync(long id)
    {
        var hotel = await hotelRepository.SelectByIdAsync(id);
        if (hotel == null)
            throw new GeoGemException(404, "Hotel is not found");

        var result = new HotelForResultDto()
        {
            Id = hotel.Id,
            LandMarkId = hotel.LandMarkId,
            Name = hotel.Name,
            Price = hotel.Price,
            NumberOfRoom = hotel.NumberOfRoom,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var hotel = await hotelRepository.SelectByIdAsync(id);
        if (hotel == null)
            throw new GeoGemException(404, "Hotel is not found");

        await hotelRepository.DeleteAsync(id);

        return true;
    }

    public async Task<HotelForResultDto> UpdateAsync(HotelForUpdateDto dto)
    {
        var hotel = await hotelRepository.SelectByIdAsync(dto.Id);
        if (hotel == null)
            throw new GeoGemException(404, "Hotel is not found");

        var mappedHotel = new Hotel()
        {
            Id = dto.Id,
            LandMarkId = dto.LandMarkId,
            Name = dto.Name,
            Price = dto.Price,
            NumberOfRoom = dto.NumberOfRoom,
            UpdatedAt = DateTime.UtcNow
        };

        await hotelRepository.UpdateAsync(mappedHotel);

        var result = new HotelForResultDto()
        {
            Id = mappedHotel.Id,
            LandMarkId = mappedHotel.LandMarkId,
            Name = mappedHotel.Name,
            Price = mappedHotel.Price,
            NumberOfRoom = mappedHotel.NumberOfRoom,
        };

        return result;
    }

    public async Task GenerateIdAsync()
    {
        var hotels = await hotelRepository.SelectAllAsync();
        if (hotels.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var hotel = hotels[hotels.Count() - 1];
            this._id = ++hotel.Id;
        }
    }
}
