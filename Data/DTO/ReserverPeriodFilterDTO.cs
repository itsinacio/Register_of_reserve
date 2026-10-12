namespace TechNova.Api.Data.DTO;

public class ReserverPeriodFilterDTO
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int PageNumber { get; set; } = 1;
}
