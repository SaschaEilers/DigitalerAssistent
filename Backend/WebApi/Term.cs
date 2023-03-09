#nullable enable
namespace WebApi;

public class Term
{
    public required string Value { get; set; }
    public required decimal Weight { get; set; }
    public required DateTimeOffset CreationTimeStamp { get; set; }
    public required DateTimeOffset ModifiedTimeStamp { get; set; }
}