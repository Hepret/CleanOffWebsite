using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanOff.Domain;

public class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid EmployeeId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}