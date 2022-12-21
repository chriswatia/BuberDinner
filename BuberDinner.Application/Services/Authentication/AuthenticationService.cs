using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infrastructure.Services.Authentication;

namespace BuberDinner.Infrastructure.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string token)
    {
        //Check if user already exists

        //Create user (generate unique ID)

        //Generate JWT Token
        Guid userId = Guid.NewGuid();
        var _token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            _token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "firstName", 
            "lastName", 
            email, 
            "token");
    }

    
}