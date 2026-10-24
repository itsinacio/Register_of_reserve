using TechNova.Api.Data.Converter.Contract;
using TechNova.Api.Data.DTO;
using TechNova.Api.Model;

namespace TechNova.Api.Data.Converter.Impl;

public class RoomConvert : IParse<RoomDTO, Room>, IParse<Room, RoomResponseDTO>
{
    public Room Parse(RoomDTO origin)
    {
        if (origin == null) return null!;
        return new Room
        {
            Id = origin.Id,
            Available = origin.Available,
            UnavailabilityReason = origin.UnavailabilityReason,
            NameRoom = origin.NameRoom,
            Capacity = origin.Capacity,
            Projector = origin.Projector
        };
    }
    public List<Room> ParseList(List<RoomDTO> origin)
    {
        if (origin == null) return null!;
        return origin.Select(item => Parse(item)).ToList();
    }

    public RoomResponseDTO Parse(Room origin)
    {
        if (origin == null) return null!;
        return new RoomResponseDTO
        {
            Available = origin.Available,
            UnavailabilityReason = origin.UnavailabilityReason,
            NameRoom = origin.NameRoom,
            Capacity = origin.Capacity,
            Projector = origin.Projector
        };
    }
    public List<RoomResponseDTO> ParseList(List<Room> origin)
    {
        if (origin == null) return null!;
        return origin.Select(item => Parse(item)).ToList();
    }
}
