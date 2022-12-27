using BuberDinner.Application.Common.Services;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
        ) : IRequest<ErrorOr<AuthenticationResult>>;
}
