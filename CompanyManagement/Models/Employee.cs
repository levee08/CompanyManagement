using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagement.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId {get;set;}

        public Department Department{ get; set;}

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string BirthPlace { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }
        [Phone]
        public string? LandlineNumber { get; set; }




    }
}
