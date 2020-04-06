using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    public class PeopleAccountDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountType { get; set; }
        public string Password { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        
        [ForeignKey("People")]
        public int PeopleId { get; set; }
        public PeopleDto People { get; set; }
    }
}