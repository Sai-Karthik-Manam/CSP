
namespace CSP.API.Models.Responses;

public class LoginUserData
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string CitizenID { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Role { get; set; }
}
