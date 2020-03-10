using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    [Table("provider")]
    public class ProviderDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}