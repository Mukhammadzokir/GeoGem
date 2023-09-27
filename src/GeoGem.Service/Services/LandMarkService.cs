
using GeoGem.Data.IRepositories;
using GeoGem.Data.Repositories;
using GeoGem.Domain.Entities;
using GeoGem.Service.DTOs.LandMarks;
using GeoGem.Service.Exceptions;
using GeoGem.Service.Interfaces;

namespace GeoGem.Service.Services;

public class LandMarkService : ILandMarkService
{
    private long _id;
    private readonly IRepository<LandMark> landMarkRepository = new Repository<LandMark>();
    public async Task<LandMarkForResultDto> CreateAsync(landMarkCreationDto dto)
    {
        var landMark = (await landMarkRepository.SelectAllAsync())
            .FirstOrDefault(l => l.Latitude == dto.Latitude && l.Longitude == dto.Longitude);
        if (landMark != null)
            throw new GeoGemException(409, "LandMark is already exist");

        await GenerateIdAsync();

        var tour = new LandMark()
        {
            Id = _id,
            CityId = dto.CityId,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            CreatedAt = DateTime.UtcNow,
        };

        await landMarkRepository.InsertAsync(tour);

        var result = new LandMarkForResultDto()
        {
            Id = _id,
            CityId = dto.CityId,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
        };

        return result;
    }

    public async Task<List<LandMarkForResultDto>> GetAllAsync()
    {
        var landMarks = await landMarkRepository.SelectAllAsync();
        var mappedLandMarks = new List<LandMarkForResultDto>();

        foreach (var landMark in landMarks)
        {
            var item = new LandMarkForResultDto()
            {
                Id = landMark.Id,
                CityId = landMark.CityId,
                Name = landMark.Name,
                Description = landMark.Description,
                ImageUrl = landMark.ImageUrl,
                Latitude = landMark.Latitude,
                Longitude = landMark.Longitude,
            };
            mappedLandMarks.Add(item);
        }
        return mappedLandMarks;
    }

    public async Task<LandMarkForResultDto> GetByIdAsync(long id)
    {
        var landMark = await landMarkRepository.SelectByIdAsync(id);
        if (landMark == null)
            throw new GeoGemException(404, "LandMark is not found");

        var result = new LandMarkForResultDto()
        {
            Id = landMark.Id,
            CityId = landMark.CityId,
            Name = landMark.Name,
            Description = landMark.Description,
            ImageUrl = landMark.ImageUrl,
            Latitude = landMark.Latitude,
            Longitude = landMark.Longitude,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var landMark = await landMarkRepository.SelectByIdAsync(id);
        if (landMark == null)
            throw new GeoGemException(404, "LandMark is not found");

        await landMarkRepository.DeleteAsync(id);

        return true;
    }

    public async Task<LandMarkForResultDto> UpdateAsync(LandMarkForUpdateDto dto)
    {
        var landMark = await landMarkRepository.SelectByIdAsync(dto.Id);
        if (landMark == null)
            throw new GeoGemException(404, "LandMark is not found");

        var meppedLandMark = new LandMark()
        {
            Id = dto.Id,
            CityId = dto.CityId,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            UpdatedAt = DateTime.UtcNow
        };

        await landMarkRepository.UpdateAsync(meppedLandMark);

        var result = new LandMarkForResultDto()
        {
            Id = dto.Id,
            CityId = dto.CityId,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
        };

        return result;
    }

    public async Task GenerateIdAsync()
    {
        var landMarks = await landMarkRepository.SelectAllAsync();
        if (landMarks.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var landMark = landMarks[landMarks.Count() - 1];
            this._id = ++landMark.Id;
        }
    }
}
