using System;
using System.ComponentModel.DataAnnotations;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    public class ProviderDto
    {
        [Key]
        public long Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}