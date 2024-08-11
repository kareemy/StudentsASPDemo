using System.ComponentModel.DataAnnotations; // Needed for Data Validation
namespace StudentsASPDemo.Models;

public class Student
{
    public int StudentID {get; set;} // Primary Key

    [Display(Name = "First Name")]
    [StringLength(20)]
    public string FirstName {get; set;} = string.Empty;

    [Display(Name = "Last Name")]
    [StringLength(50)]
    public string LastName {get; set;} = string.Empty;

    [StringLength(20, MinimumLength = 3)]
    public string Major {get; set;} = string.Empty;
    
    [Range(1, 99)]
    public int Age {get; set;}
}