using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreExample.Models
{
    [Table("department")]
    public class Department
    {
        [Key]
        [Column("department_id")]
        public int Id { get; set; }
        [Column("department_name")]
        public string Name { get; set; }

        [Column("department_location")]
        public int LocationRefId { get; set; }

        [ForeignKey("LocationRefId")]
        public Location Location { get; set; }

        //public List<Employee> Employees { get; set; }
    }
}
