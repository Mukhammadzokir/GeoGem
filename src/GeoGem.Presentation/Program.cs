using GeoGem.Presentation.Presentations;
using GeoGem.Service.DTOs.Hotels;
using GeoGem.Service.Services;

namespace GeoGem.Presentation;

public class Program
{
    static async Task Main(string[] args)
    {
        var UI = new UserInterface();
        
        await UI.RunningCodeAsync();

    }
}