using System.ComponentModel.DataAnnotations;

namespace Lab2.DataAccess;

public class Department
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(2)]
    public required string Code { get; set; }

    [Required]
    [Range(1, 5)]
    public required int FloorNumber { get; set; }

    [Required]
    [Phone]
    public required string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    public bool IsHiring { get; set; } = false;

    [DataType(DataType.DateTime)]
    public DateTime? LastAuditDateTime { get; set; }

    [StringLength(200)]
    public string? Description { get; set; }

    public List<Employee> Employees { get; set; } = new();
}
