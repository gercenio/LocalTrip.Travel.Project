using System;
using System.ComponentModel.DataAnnotations;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    public class TripDto
    {
        [Key]
        public long Id { get; set; }
        public long ProviderId { get; set; }
        public string Name { get; set; }
        public string PrimaryImage { get; set; }
        public string CountryOrigem { get; set; }
        public string CountryDestination { get; set; }
        public string CityOrigem { get; set; }
        public string CityDestination { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}