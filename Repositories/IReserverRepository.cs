using TechNova.Api.Data.DTO;
using TechNova.Api.Model;

namespace TechNova.Api.Repositories;

public interface IReserverRepository : IRepository<Reserve>
{
    List<Reserve> FindByRoomId(long roomId, int pageNumber);
    List<Reserve> FindByPeriod(ReserverPeriodFilterDTO filter);
    bool ExistReserveThisHours(DateTime start, DateTime end, long roomId);
}
