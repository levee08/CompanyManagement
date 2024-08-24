using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagement.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]  
        public decimal Budget { get; set; }


        public List<Employee>? Employees = new List<Employee>();

    }
}
