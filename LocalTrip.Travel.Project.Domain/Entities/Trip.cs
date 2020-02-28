using System;
using System.Collections.Generic;
using System.Text;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public sealed class Trip
    {
        public string Description { get; private set; }
        public DateTime ExitDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public OrigemTrip Origem { get; private set; }
        public DestinationTrip Destination { get; private set; }
        public IEnumerable<IncludeItensOnTrip> includeItensOnTrips { get; }
        public IEnumerable<ExcludeItensOnTrip> ExcludeItensOnTrips { get; }

        public Trip(string description
            , DateTime exitDate
            , DateTime returnDate) {

            Description = description;
            ExitDate = exitDate;
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
       
    }
}
