namespace DemoCleanArch.DTOs;


//Kimlik doğrulama için gerekli alan


public class Token
{
    public string AccessToken { get; set; }
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; }
}