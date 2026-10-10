using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechNova.Api.Model.Base;

namespace TechNova.Api.Model;
[Table("Rooms")]
public class Room : Entity
{
    [Required]
    [Column("NameRoom",TypeName = "varchar(255)")]
    public string NameRoom {get; set;} = string.Empty;
    [Column("Capacity")]
    public byte Capacity{get;set;}
    [Column("Projector")]
    public bool Projector{get;set;}
}