using ErrorOr;

namespace BuberDinner.Infrastructure.Services.Authentication;

public interface IAuthenticationService{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}