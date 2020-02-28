using System;
using System.Collections.Generic;
using System.Text;
using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public sealed class Trip
    {
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public OrigemTrip Origem { get; private set; }
        public DestinationTrip Destination { get; private set; }

        public Decimal Value { get; private set; }
        
        public string PrimaryImage { get; set; }

        public Enuns.TypeAccommodations Accommodations { get; private set; }

        public IEnumerable<IncludeItensOnTrip> includeItensOnTrips { get; }
        public IEnumerable<ExcludeItensOnTrip> ExcludeItensOnTrips { get; }
        public IEnumerable<ImagensTrip> Imagens { get; set; }

        public Trip(string description
            , DateTime startDate
            , DateTime returnDate) {

            Description = description;
            StartDate = startDate;
            ReturnDate = returnDate;

        }

        public void AddOrigem(string description,string station)
        {
            Origem = new OrigemTrip(description, station);
        }

        public void AddDestination(string description,string station)
        {
            Destination = new DestinationTrip(description, station);
        }
        
        public void AddAccommodations(TypeAccommodations t)
        {
            Accommodations = t;
        }
    }
}
