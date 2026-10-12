using TechNova.Api.Model.Enum;

namespace TechNova.Api.Data.DTO;

public class ReserveResponseDTO
{
    public ReserverStatus Status { get; set; } = ReserverStatus.Active;
    public bool NeedProjector { get; set; }
    public byte RequiredCapacity { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public DateTime StartOfReserve { get; set; }
    public DateTime EndOfReserve { get; set; }
    public long RoomId { get; set; }
}
