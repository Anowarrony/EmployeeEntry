using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EmployeesEntry.Models
{[Table("tblPosition")]
    public class Position
    {
        [Key]
        public long PositionId { get; set; }
      
        public string PositionName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}