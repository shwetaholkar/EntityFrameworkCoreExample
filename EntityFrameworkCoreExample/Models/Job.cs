using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreExample.Models
{

    [Table("job")]
    public class Job
    {
        [Key]
        [Column("job_id")]
        public int Id { get; set; }
        [Column("job_name")]
        public string Name { get; set; }

        [Column("min_salary")]
        public int MinSalary { get; set; }

        [Column("max_salary")]
        public int MaxSalary { get; set; }

    }
}
