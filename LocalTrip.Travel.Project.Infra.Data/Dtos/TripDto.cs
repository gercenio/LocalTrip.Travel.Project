using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    [Table("trip")]
    public class TripDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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