using System.ComponentModel.DataAnnotations;
namespace CSP.API.Models.Requests;
public class LoginModel
{
    public string Email{get;set;}=string.Empty;
    public string Password{get;set;}=string.Empty;
}