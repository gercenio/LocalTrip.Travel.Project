using System;
using System.Collections.Generic;
using System.Text;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class OrigemTrip
    {
        public string Description { get; private set; }
        public string Station { get; private set; }

        public OrigemTrip(string description, string station)
        {
            Description = description;
            Station = station;
        }
    }
}
