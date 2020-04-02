using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocalTrip.Travel.Project.Domain.Entities;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    public class DestinationDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }

        public decimal Price { get; set; }

        public string Url { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        public string TokenImage { get; set; }

        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        
        public ICollection<DestinationActivitiesDto> DestinationActivitieses { get; set; }

    }
}