namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class DestinationActivities
    {
        public string Name { get; }
        public int Rating { get; }

        public DestinationActivities(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }
    }
}