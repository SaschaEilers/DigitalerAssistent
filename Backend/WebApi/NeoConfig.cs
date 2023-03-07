#nullable enable
namespace WebApi;

public class NeoConfig
{
    public string Host { get; set; } = string.Empty;
    public short Port { get; set; }
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}