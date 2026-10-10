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
    [Column("EmployeeName", TypeName = "varchar(255)")]
    public string EmployeeName { get; set; } = string.Empty;
    [Required]
    [Column("StartOfReserve")]
    public DateTime StartOfReserve { get; set; }
    [Required]
    [Column("EndOfReserve")]
    public DateTime EndOfReserve { get; set; }
    [Column("RoomId")]
    public long RoomId { get; set; }
    [ForeignKey("RoomId")]
    public virtual Room Room { get; set; } = new Room();
}
