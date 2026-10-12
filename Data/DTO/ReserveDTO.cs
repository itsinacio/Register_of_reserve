using TechNova.Api.Model.Enum;

namespace TechNova.Api.Data.DTO;

public class ReserveDTO
{
    public long Id {get;set;}
    public ReserverStatus Status { get; set; } = ReserverStatus.Active;
    public string EmployeeName { get; set; } = string.Empty;
    public DateTime StartOfReserve { get; set; }
    public DateTime EndOfReserve { get; set; }
    public long RoomId { get; set; }
}
