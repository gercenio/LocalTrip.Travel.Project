using System.Collections.Generic;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class Destination
    {
        public string Name { get; }

        public int Rating { get; private set; }

        public decimal Price { get; }

        public string Url { get; }

        public string Country { get; }

        public string City { get; }

        public string TokenImage { get; }

        public virtual List<DestinationActivities> Activities { get; private set; }
        public virtual List<DestinationImage> Images { get; private set; }

        public Destination(string name
            , decimal price
            , string url
            , string country
            , string city
            , string token)
        {
            Name = name;
            Price = price;
            Url = url;
            Country = country;
            City = city;
            TokenImage = token;
            Activities = new List<DestinationActivities>();
            Images = new List<DestinationImage>();
        }

        public void AddRating(int rating)
        {
            Rating = rating;
        }

        public void AddActivities(DestinationActivities activities)
        {
            Activities.Add(activities);
        }

        public void AddImage(DestinationImage image)
        {
            Images.Add(image);
        }

    }
}