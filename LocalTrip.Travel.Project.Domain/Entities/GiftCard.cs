using System;
using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class GiftCard
    {
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageValue { get; private set; }
        public TypeGiftCard Type { get; private set; }
        public DateTime ValidDate { get; private set; }

        public GiftCard(string name,string imageValue)
        {
            Name = name;
            ImageValue = imageValue;

        }

        public void AddType(TypeGiftCard t)
        {
            Type = t;
        }

        public void AddValidDate(DateTime dt)
        {
            ValidDate = dt;
        }

        public void AddDescripton(string description)
        {
            Description = description;
        }
    }
}