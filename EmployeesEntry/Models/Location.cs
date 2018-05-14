
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EmployeesEntry.Models
{
    [Table("tblLocation")]
    public class Location
    {
        [Key]
        public long LocationId { get; set; }
   
        public string LocationName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}