using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocalTrip.Travel.Project.Domain.Entities;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    public class DestinationActivitiesDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Destination")]
        public int DestinationId { get; set; }
        public DestinationDto Destination { get; set; }

        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}