using System;
using System.Collections.Generic;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class Cart
    {
        public int Id { get; }

        public int PeopleId { get; set; }

        public DateTime CreatedDate { get; }

        public People People { get; private set; }

        public List<CartItem> Itens { get; private set; }

        public Cart(int id, int peopleId)
        {
            Id = id;
            PeopleId = peopleId;
            CreatedDate = DateTime.Now;
            Itens = new List<CartItem>();
        }

        public void AddPeople(People p)
        {
            People = p;
        }

        public void AddItem(CartItem i)
        {
            Itens.Add(i);
        }

    }
    
}