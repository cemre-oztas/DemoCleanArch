namespace DemoCleanArch.DTOs.User;


//Oluşturma işleminin sonucunu temsil eder.


public class CreateUserResponse
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
}