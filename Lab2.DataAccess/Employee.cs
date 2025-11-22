using System.ComponentModel.DataAnnotations;

namespace Lab2.DataAccess;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public required string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    [Phone]
    public required string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [StringLength(50)]
    public required string Position { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public required DateOnly HireDate { get; set; }

    [Required]
    public required decimal Salary { get; set; }

    [Range(0, 100)]
    public int? PerformanceScore { get; set; }

    public bool IsOnLeave { get; set; } = false;

    public required Department Department { get; set; }

    public List<LeaveRequest> LeaveRequests { get; set; } = new();
}
