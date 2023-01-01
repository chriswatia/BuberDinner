using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Host.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public HostId(string value)
        {
            Value = value;
        }

        public string Value { get; }
        public static HostId Create(UserId userId)
        {
            return new HostId($"Host_{userId.Value}");
        }

        public static HostId Create(string hostId)
        {
            return new HostId(hostId);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
