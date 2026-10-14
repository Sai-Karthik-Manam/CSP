
namespace CSP.API.Models.Responses;

public class ServiceResponseModel
{
    public int ServiceID { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string? Description { get; set; }
}
