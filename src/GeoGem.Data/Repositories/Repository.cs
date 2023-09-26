using GeoGem.Data.IRepositories;
using Newtonsoft.Json;
using GeoGem.Domain.Commons;
using GeoGem.Domain.Entities;
using GeoGem.Domain.Configurations;

namespace GeoGem.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly string Path;

    public Repository()
    {
        if (typeof(TEntity) == typeof(User))
        {
            this.Path = DatabasePath.UserDb;
        }
        else if (typeof(TEntity) == typeof(City))
        {
            this.Path = DatabasePath.CityDb;
        }
        else if (typeof(TEntity) == typeof(LandMark))
        {
            this.Path = DatabasePath.LandMarkDb;
        }
        else if(typeof(TEntity) == typeof(Ticket))
        {
            this.Path = DatabasePath.TicketDb;
        }
        else if(typeof(TEntity) == typeof(Booking))
        {
            this.Path = DatabasePath.BookingDb;
        }
        else
        {
            this.Path = DatabasePath.HotelDb;
        }


        var str = File.ReadAllText(Path);
        if (string.IsNullOrEmpty(str))
        {
            File.WriteAllText(Path, "[]");
        }
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entities = await SelectAllAsync();
        var entity = entities.FirstOrDefault(e => e.Id == id);
        entities.Remove(entity);
        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.WriteAllTextAsync(Path, str);

        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var str = await File.ReadAllTextAsync(Path);
        var entites = JsonConvert.DeserializeObject<List<TEntity>>(str);
        entites.Add(entity);
        var result = JsonConvert.SerializeObject(entites, Formatting.Indented);
        await File.WriteAllTextAsync(Path, result);

        return entity;
    }

    public async Task<List<TEntity>> SelectAllAsync()
    {
        var str = await File.ReadAllTextAsync(Path);
        var entities = JsonConvert.DeserializeObject<List<TEntity>>(str);
        return entities;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        return (await SelectAllAsync()).FirstOrDefault(e => e.Id == id);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entites = await SelectAllAsync();
        await File.WriteAllTextAsync(Path, "[]");

        foreach (var ent in entites)
        {
            if (ent.Id == entity.Id)
            {
                await InsertAsync(entity);
                continue;
            }
            await InsertAsync(ent);
        }

        return entity;
    }
}
