using LocalTrip.Core.Api.Enuns;

namespace LocalTrip.Core.Api.ViewModels
{
    public class AccountUpdateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public string Phone { get; set; }
        public PeopleType Type { get; set; }
    }
}