namespace CleanArch.Domain.Entities.Identity;

public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser<string>
{
    public string Id { get; set; }
    public required string NameSurname { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
    public ICollection<BasketEntity> Baskets { get; set; }

}
