using LocalTrip.Core.Api.Enuns;

namespace LocalTrip.Core.Api.ViewModels
{
    public class AccountRegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public PeopleType Type { get; set; }
    }
}