using System.ComponentModel.DataAnnotations;
namespace CSP.API.Models.Requests;
public class RegistrationModel
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string MobileNumber { get; set; } = string.Empty;
    [Required]
    public DateTime DOB {get;set;}
    [Required]
    public string Password { get; set; } = string.Empty;
    public IFormFile Image { get; set; } = null!;
    public string Photo { get; set; } = string.Empty;
}