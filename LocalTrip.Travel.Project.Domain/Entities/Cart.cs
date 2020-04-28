using System;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class Cart
    {
        public int Id { get; }
        public DateTime CreatedDate { get; }

        public Cart(int id)
        {
            Id = id;
            CreatedDate = DateTime.Now;
        }
    }
}