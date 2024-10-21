using Microsoft.AspNetCore.Identity;


namespace CleanArch.Domain.Entities.Identity;

public class AppRole : IdentityRole<string>
{
    public string? Description { get; set; }

}
