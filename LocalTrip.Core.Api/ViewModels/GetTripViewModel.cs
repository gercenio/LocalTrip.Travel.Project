using System;

namespace LocalTrip.Core.Api.ViewModels
{
    public class GetTripViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
    }
}