namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class Payment
    {
        public int Id { get; private set; }
        public string Name { get; }

        public Payment(string name)
        {
            Name = name;
        }

        public void AddIdentity(int id)
        {
            Id = id;
        }
    }
}