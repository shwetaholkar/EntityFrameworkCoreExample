using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreExample.Models
{
    [Table("location")]
    public class Location
    {
        [Key]
        [Column("location_id")]
        public int Id { get; set; }
        [Column("location_name")]
        public string Name { get; set; }

        [Column("location_pincode")]
        public string Pincode { get; set; }
    }
}
