namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; private set; }
        public int OrderId { get; }
        public decimal Value { get; }
        
    }
}