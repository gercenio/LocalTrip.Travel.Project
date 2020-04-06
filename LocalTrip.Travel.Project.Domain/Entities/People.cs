using System.Collections.Generic;
using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class People
    {
        public string Document { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public PeopleType Type { get; private set; }

        public PeopleAccount Account { get; private set; }

        public List<PeopleContact> Contacts { get; private set; }

        public People(string document, string firstName, string lastName)
        {
            Document = document;
            FirstName = firstName;
            LastName = lastName;
            Contacts = new List<PeopleContact>();
        }

        public void AddPeopleType(PeopleType t)
        {
            Type = t;
        }

        public void AddContact(PeopleContact contact)
        {
            Contacts.Add(contact);
        }

        public void AddAccount(PeopleAccount account)
        {
            Account = account;
        }


    }
}