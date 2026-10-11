namespace CSP.API.Models.Responses;
public class LoginResponseModel
{
    public int Id{get;set;}
    public string UserName{get;set;}=string.Empty;
    public string CitizenID{get;set;}=string.Empty;
    public int Role{get;set;}
    public int Flag{get;set;}
    public string Message{get;set;}=string.Empty;
}