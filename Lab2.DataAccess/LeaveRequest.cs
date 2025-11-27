using System.ComponentModel.DataAnnotations;

namespace Lab2.DataAccess;

public class LeaveRequest
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public required string Type { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public required DateTime StartDateTime { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public required DateTime EndDateTime { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public required DateTime RequestDateTime { get; set; }

    [StringLength(200)]
    public string? Comments { get; set; }

    public int? ApprovedById { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? ApprovalDateTime { get; set; }

    [StringLength(200)]
    public string? ApprovalComments { get; set; }

    //public required Employee Employee { get; set; }

    public int EmployeeId { get; set; }
}
