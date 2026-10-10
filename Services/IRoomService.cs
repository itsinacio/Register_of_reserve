using TechNova.Api.Data.DTO;
using TechNova.Api.Model;

namespace TechNova.Api.Services;

public interface IRoomService
{
    RoomResponseDTO Create(RoomDTO room);
    RoomResponseDTO FindById(long id);
    List<RoomResponseDTO> FindList(int pageNumber = 1);
    RoomResponseDTO Update(RoomDTO room);
    void SetUnavailable(long id, string reason);
    void SetAvailable(long id);
}