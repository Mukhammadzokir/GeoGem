using GeoGem.Data.IRepositories;
using GeoGem.Data.Repositories;
using GeoGem.Domain.Entities;
using GeoGem.Service.DTOs.Cities;
using GeoGem.Service.DTOs.Users;
using GeoGem.Service.Exceptions;
using GeoGem.Service.Interfaces;

namespace GeoGem.Service.Services;

public class CityService : ICityService
{
    private long _id;
    private readonly IRepository<City> cityRepository = new Repository<City>();
    public async Task<CityForResultDto> CreateAsync(CityForCreationDto dto)
    {
        var city = (await cityRepository.SelectAllAsync())
            .FirstOrDefault(c => c.Latitude == dto.Latitude && c.Longitude == dto.Longitude);
        if (city != null)
            throw new GeoGemException(409, "City is already exist");

        await GenerateIdAsync();

        var tour = new City()
        {
            Id = _id,
            Name = dto.Name,
            ImageUrl = dto.ImageUrl,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            CreatedAt = DateTime.UtcNow,
        };

        await cityRepository.InsertAsync(tour);

        var result = new CityForResultDto()
        {
            Id = _id,
            Name = dto.Name,
            ImageUrl = dto.ImageUrl,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
        };

        return result;
    }

    public async Task<List<CityForResultDto>> GetAllAsync()
    {
        var cities = await cityRepository.SelectAllAsync();
        var mappedCities = new List<CityForResultDto>();

        foreach (var city in cities)
        {
            var item = new CityForResultDto()
            {
                Id = city.Id,
                Name = city.Name,
                ImageUrl = city.ImageUrl,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
            };
            mappedCities.Add(item);
        }
        return mappedCities;
    }

    public async Task<CityForResultDto> GetByIdAsync(long id)
    {
        var city = await cityRepository.SelectByIdAsync(id);
        if (city == null)
            throw new GeoGemException(404, "City is not found");

        var result = new CityForResultDto()
        {
            Id = city.Id,
            Name = city.Name,
            ImageUrl = city.ImageUrl,
            Latitude = city.Latitude,
            Longitude = city.Longitude,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var city = await cityRepository.SelectByIdAsync(id);
        if (city == null)
            throw new GeoGemException(404, "City is not found");

        await cityRepository.DeleteAsync(id);

        return true;
    }

    public async Task<CityForResultDto> UpdateAsync(CityForUpdateDto dto)
    {
        var city = await cityRepository.SelectByIdAsync(dto.Id);
        if (city == null)
            throw new GeoGemException(404, "City is not found");

        var meppedCity = new City()
        {
            Id = dto.Id,
            Name = dto.Name,
            ImageUrl = dto.ImageUrl,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            UpdatedAt = DateTime.UtcNow
        };

        await cityRepository.UpdateAsync(meppedCity);

        var result = new CityForResultDto()
        {
            Id = meppedCity.Id,
            Name = meppedCity.Name,
            ImageUrl = meppedCity.ImageUrl,
            Latitude = meppedCity.Latitude,
            Longitude = meppedCity.Longitude,
        };

        return result;
    }

    public async Task GenerateIdAsync()
    {
        var cities = await cityRepository.SelectAllAsync();
        if (cities.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var city = cities[cities.Count() - 1];
            this._id = ++city.Id;
        }
    }
}
