namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class DestinationImage
    {
        public string Name { get; }
        public string Url { get; }

        public DestinationImage(string name, string url)
        {
            Url = url;
            Name = name;
        }
    }
}