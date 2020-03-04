using System;

namespace LocalTrip.Core.Api.ViewModels
{
    public class GetTripViewModel
    {
        public string CityOrigem { get; set; }
        public string CountryOrigem { get; set; }
        public DateTime DateTrip { get; set; }
        public string CityDestination { get; set; }
        public string CountryDestination { get; set; }
    }
}