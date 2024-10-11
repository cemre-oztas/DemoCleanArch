using System.Net;

namespace CleanArch.Domain.Entities.Identity;

public class AppRole : IdentityRole<string>
{

    public ICollection<Endpoint> Endpoints { get; set; }
}
