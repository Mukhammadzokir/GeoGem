using GeoGem.Presentation.Presentations;

namespace GeoGem.Presentation;

public class Program
{
    static async Task Main(string[] args)
    {
        var UI = new UserInterface();
        await UI.RunningCodeAsync();
    }
}