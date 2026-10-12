using TechNova.Api.Data.Converter.Contract;
using TechNova.Api.Data.DTO;
using TechNova.Api.Model;
using TechNova.Api.Model.Enum;

namespace TechNova.Api.Data.Converter.Impl;

public class ReserverConvert : IParse<ReserveDTO, Reserve>, IParse<Reserve, ReserveResponseDTO>
{
    public Reserve Parse(ReserveDTO origin)
    {
        if (origin == null) throw new ArgumentNullException(nameof(origin));
        return new Reserve
        {
            Id = origin.Id,
            Status = origin.Status,
            EmployeeName = origin.EmployeeName,
            StartOfReserve = origin.StartOfReserve,
            EndOfReserve = origin.EndOfReserve,
            RoomId = origin.RoomId
        };
    }
    public List<Reserve> ParseList(List<ReserveDTO> origin)
    {
        if (origin == null) throw new ArgumentNullException(nameof(origin));
        return origin.Select(item => Parse(item)).ToList();
    }

    public ReserveResponseDTO Parse(Reserve origin)
    {
        if (origin == null) throw new ArgumentNullException(nameof(origin));
        return new ReserveResponseDTO
        {
            Status = origin.Status,
            EmployeeName = origin.EmployeeName,
            StartOfReserve = origin.StartOfReserve,
            EndOfReserve = origin.EndOfReserve,
            RoomId = origin.RoomId
        };
    }
    public List<ReserveResponseDTO> ParseList(List<Reserve> origin)
    {
        if (origin == null) throw new ArgumentNullException(nameof(origin));
        return origin.Select(item => Parse(item)).ToList();
    }
}