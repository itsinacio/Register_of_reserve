namespace TechNova.Api.Data.DTO;

public class ReserveResponseDTO
{
    public string EmployeeName { get; set; } = string.Empty;
    public DateTime StartOfReserve { get; set; }
    public DateTime EndOfReserve { get; set; }
    public long RoomId { get; set; }
}
