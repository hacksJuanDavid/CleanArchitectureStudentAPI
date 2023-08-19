using System.ComponentModel.DataAnnotations;
using Student.Domain.Common;

namespace Student.Domain.Entities;

public class StudentEntity : EntityBase
{
    [Required] public string? FirstName { get; set; }
    [Required] public string? LastName { get; set; }
    [Required] public DateTime DateOfBirth { get; set; }

    [Required]
    [RegularExpression(@"[M|F]", ErrorMessage = "Invalid Sex Value")]
    public char Sex { get; set; }
}