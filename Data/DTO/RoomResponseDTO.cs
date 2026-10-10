namespace TechNova.Api.Data.DTO;

public class RoomResponseDTO
{
    public bool Available { get; set; } = true;
    public string? UnavailabilityReason { get; set; } = null;
    public string NameRoom { get; set; } = string.Empty;
    public byte Capacity { get; set; }
    public bool Projector { get; set; }
}
