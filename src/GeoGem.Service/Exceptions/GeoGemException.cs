namespace GeoGem.Service.Exceptions;

public class GeoGemException : Exception
{
    public int StatusCode { get; set; }

    public GeoGemException(int code, string message) : base(message)
    {
        this.StatusCode = code;
    }
}
