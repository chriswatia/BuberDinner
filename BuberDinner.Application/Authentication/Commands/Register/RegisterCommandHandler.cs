﻿using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Services;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.User;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : 
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // 1. Validate the user doesn't exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return AuthenticationErrors.DuplicateEmail;
            }

            // 2. Create user (generate unique ID) & persist to DB            
            var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);

            _userRepository.Add(user);

            // 3. Generate JWT Token
            var _token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                _token);
        }
    }
}
