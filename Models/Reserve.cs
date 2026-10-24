using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNova.Api.Model.Base;
using TechNova.Api.Model.Enum;

namespace TechNova.Api.Model;

[Table("Reservations")]
public class Reserve : Entity
{
    [Required]
    [Column("Status")]
    public ReserverStatus Status { get; set; } = ReserverStatus.Active;
    [Required]
    [Column("NeedProjector")]
    public bool NeedProjector { get; set; }
    [Required]
    [Column("RequiredCapacity")]
    public byte RequiredCapacity { get; set; }
    [Required]
    [Column("EmployeeName", TypeName = "varchar(255)")]
    public string EmployeeName { get; set; } = string.Empty;
    [Required]
    [Column("StartOfReserve")]
    public DateTime StartOfReserve { get; set; }
    [Required]
    [Column("EndOfReserve")]
    public DateTime EndOfReserve { get; set; }
    [Required]
    [Column("RoomId")]
    public long RoomId { get; set; }
}
