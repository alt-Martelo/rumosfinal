using Project1_Angular.Models;

public interface ITokenService
{
    Task<string> CreateTokenAsync(ApplicationUser user);
}
