using TechNova.Api.Data.DTO;
using TechNova.Api.Model;
using TechNova.Api.Model.Context;
using TechNova.Api.Model.Enum;

namespace TechNova.Api.Repositories.Impl;

public class ReserverRepositoryImpl : GenericRepository<Reserve>, IReserverRepository
{
    public ReserverRepositoryImpl(SqlServerContext context) : base(context)
    {
    }
    public List<Reserve> FindByRoomId(long roomId, int pageNumber = 1)
    {
        return _dataset
            .Where(x => x.RoomId == roomId)
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * 15)
            .Take(15)
            .ToList();
    }
    public List<Reserve> FindByPeriod(ReserverPeriodFilterDTO filter)
    {
        if(filter.Start >= filter.End) throw new InvalidOperationException("Hour start of reserver not is up or equal this hour end of reserver");
        return _dataset
            .Where(x => x.Status == ReserverStatus.Active &&
                    ((filter.Start <= x.StartOfReserve && filter.End > x.StartOfReserve) ||
                    (filter.Start < x.EndOfReserve && filter.End >= x.EndOfReserve)))
            .OrderBy(x => x.Id)
            .Skip((filter.PageNumber - 1) * 15)
            .Take(15)
            .ToList();
    }
    public bool ExistReserveThisHours(DateTime Start, DateTime End, long roomId)
    {
        var aux = _dataset.FirstOrDefault(x =>
            x.Status == ReserverStatus.Active &&
            x.RoomId == roomId &&
            ((Start <= x.StartOfReserve && End > x.StartOfReserve) || (Start < x.EndOfReserve && End >= x.EndOfReserve)));

        return aux != null;
    }
}
