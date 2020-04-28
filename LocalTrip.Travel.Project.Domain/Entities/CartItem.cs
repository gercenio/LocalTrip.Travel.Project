namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; private set; }

        public int DestinationId { get; }
        public int PeopleId { get; }
        public int CartId { get; }
        public int Count { get; }

        public Destination Destination { get; private set; }

        public CartItem(int destinationId, int peopleId, int cartId, int count)
        {
            DestinationId = destinationId;
            PeopleId = peopleId;
            CartId = cartId;
            Count = count;
        }

        public void AddIdentity(int id)
        {
            Id = id;
        }

        public void AddDestination(Destination destination)
        {
            Destination = destination;
        }

    }
}