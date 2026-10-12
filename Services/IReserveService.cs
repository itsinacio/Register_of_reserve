using TechNova.Api.Data.DTO;

namespace TechNova.Api.Services;

public interface IReserveService
{
    ReserveResponseDTO Create(ReserveDTO reserve);
    ReserveResponseDTO FindById(long id);
    List<ReserveResponseDTO> FindList(int pageNumber = 1);
    List<ReserveResponseDTO> FindByRoomId(long roomId, int pageNumber = 1);
    List<ReserveResponseDTO> FindByPeriod(ReserverPeriodFilterDTO filter);
    void Canceled (long id);
    void Completed (long id);
    void Delete(long id);
}