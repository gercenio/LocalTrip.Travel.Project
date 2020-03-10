using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalTrip.Travel.Project.Infra.Data.Dtos
{
    [Table("apiaccount")]
    public class ApiAccountDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string AccessKey { get; set; }
    }
}