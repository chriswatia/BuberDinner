﻿using BuberDinner.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Services
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
