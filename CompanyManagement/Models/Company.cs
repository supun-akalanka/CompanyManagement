using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagement.Models
{
    public class Company
    {
        public  Guid Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName ="nvarchar(max")]
        public string Name { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "nvarchar(max")]
        public string Address { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "nvarchar(max")]
        public string Contact { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar(max")]
        public string Email { get; set; }
    }
}
