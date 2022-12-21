using BuberDinner.Infrastructure.Services.Authentication;

namespace BuberDinner.Infrastructure.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "firstName", 
            "lastName", 
            email, 
            "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string token)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            firstName, 
            lastName, 
            email, 
            "token");
    }
}