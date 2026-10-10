using TechNova.Api.Data.DTO;

namespace TechNova.Api.Services;

public interface IReserveService
{
    ReserveResponseDTO Create(ReserveDTO reserve);
    ReserveResponseDTO FindById(long id);
    List<ReserveResponseDTO> FindList(int pageNumber = 1);
    List<ReserveResponseDTO> FindByRoomId(long roomId);
    List<ReserveResponseDTO> FindByPeriod(DateTime start, DateTime end);
    void Canceled (long id);
    void Completed (long id);
    ReserveResponseDTO Update(ReserveDTO reserve);
    void Delete(long id);
}
