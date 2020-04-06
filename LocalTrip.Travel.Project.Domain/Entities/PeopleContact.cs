using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class PeopleContact
    {
        public ContactType Type { get; }
        public string Value { get; }

        public PeopleContact(ContactType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}