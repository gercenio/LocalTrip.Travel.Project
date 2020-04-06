using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class PeopleAccount
    {
        public AccountType Type { get; }
        public string Password { get; }

        public PeopleAccount(AccountType type, string password)
        {
            Password = password;
            Type = type;
        }
    }
}