using System;
using LocalTrip.Travel.Project.Application.Commands.Response;
using MediatR;

namespace LocalTrip.Travel.Project.Application.Commands.Request
{
    public class FindTripCommandRequest :IRequest<FindTripCommandResponse>
    {
        public decimal Price { get; }

        public string City { get; }

        public string Country { get; }

        public FindTripCommandRequest(decimal price, string city, string country)
        {
            Price = price;
            City = city;
            Country = country;
        }

        
    }
}