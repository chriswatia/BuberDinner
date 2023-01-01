using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private User(
            string firstName,
            string lastName,
            string email,
            string password,
            UserId? userId = null)
            :base(userId ?? UserId.CreateUnique())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            return new User(
                firstName,
                lastName,
                email,
                password);
        }

    }
}
