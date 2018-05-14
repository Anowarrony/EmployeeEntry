using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesEntry.Models
{
    [Table("tblEmployee")]
    public class Employee

    {
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee Name is required!")]
        public string EmployeeName { get; set; }
        [Display(Name = "Present Address")]
        [Required(ErrorMessage = "Present Address is required!")]
        public string PresentAddress { get; set; }
        [Display(Name = "Parmanent address")]
        [Required(ErrorMessage = "Parmanent Address is required!")]
        public string ParmanentAddress { get; set; }
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required!")]
        public long LocationId { get; set; }
        [Display(Name = "Position")]
        [Required(ErrorMessage = "Position is required!")]
        public long PositionId { get; set; }
        [Display(Name = "Current salary")]
        [Required(ErrorMessage = "Current Salary is required!")]
        public double CurrentSalary { get; set; }
        [Display(Name = "Sex")]
        [Required(ErrorMessage = "Sex is required!")]
        public string Gender { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number is required!")]
        public decimal Phone { get; set; }
        [Display(Name = "Is User Of System")]
        public bool IsUserOfSystem { get; set; }
        public string MaritalStatus { get; set; }
        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="DOB is required!")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Joinign date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Joining Date is required!")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
        public virtual Location Location { get; set; }
        public virtual Position Position { get; set; }
    }
}