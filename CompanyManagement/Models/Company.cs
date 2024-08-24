using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CompanyManagement.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public int TaxNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime FoundedDate { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

    }
}
