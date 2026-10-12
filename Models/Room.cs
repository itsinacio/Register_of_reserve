using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNova.Api.Model.Base;

namespace TechNova.Api.Model;

[Table("Rooms")]
public class Room : Entity
{
    [Required]
    [Column("Available")]
    public bool Available { get; set; } = true;
    [Column("UnavailabilityReason", TypeName = "varchar(255)")]
    public string? UnavailabilityReason { get; set; } = null;
    [Required]
    [Column("NameRoom", TypeName = "varchar(255)")]
    public string NameRoom { get; set; } = string.Empty;
    [Required]
    [Column("Capacity")]
    public byte Capacity { get; set; }
    [Required]
    [Column("Projector")]
    public bool Projector { get; set; }
}