using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
