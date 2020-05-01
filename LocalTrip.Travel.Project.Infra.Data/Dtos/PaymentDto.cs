using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    [Table("payment")]
    public class PaymentDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}