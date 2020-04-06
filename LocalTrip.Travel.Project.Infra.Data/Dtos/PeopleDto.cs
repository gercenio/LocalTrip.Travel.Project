using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocalTrip.Travel.Project.Domain.Entities;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    public class PeopleDto
    {
        
        public PeopleDto()
        {
            Contacts = new List<PeopleContactDto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Document { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PeopleType { get; set; }
        public PeopleAccountDto Account { get; set; }
        public List<PeopleContactDto> Contacts { get; set; }

        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}