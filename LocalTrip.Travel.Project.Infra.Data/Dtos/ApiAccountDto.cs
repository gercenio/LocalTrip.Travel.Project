using System.ComponentModel.DataAnnotations;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    public class ApiAccountDto
    {
        [Key]
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string AccessKey { get; set; }
    }
}