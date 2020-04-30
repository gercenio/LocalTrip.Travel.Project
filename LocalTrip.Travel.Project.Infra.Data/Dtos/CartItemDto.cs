using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocalTrip.Travel.Project.Domain.Entities;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    [Table("cartitem")]
    public class CartItemDto
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("Destination")]
        public int DestinationId { get; set; }
        public DestinationDto Destination { get; set; }
        
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public CartDto Cart { get; set; }

        public int Count { get; set; }
        
        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}