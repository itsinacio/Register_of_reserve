namespace TechNova.Api.Data.DTO;

public class RoomDTO
{
    public long Id { get; set; }
    public string NameRoom { get; set; } = string.Empty;
    public byte Capacity { get; set; }
    public bool Projector { get; set; }
}
