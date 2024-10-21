namespace DemoCleanArch.DTOs.User;


//Yeni bir kullanıcı oluşturmak için gerekli alan

public class CreateUser
{
    public string NameSurname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }

    public string? RefreshToken { get; set; }
}