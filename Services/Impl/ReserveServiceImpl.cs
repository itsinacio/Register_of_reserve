using Azure;
using Microsoft.EntityFrameworkCore;
using TechNova.Api.Data.Converter.Impl;
using TechNova.Api.Data.DTO;
using TechNova.Api.Model;
using TechNova.Api.Model.Context;
using TechNova.Api.Model.Enum;
using TechNova.Api.Repositories;

namespace TechNova.Api.Services.Impl;

public class ReserveServiceImpl : IReserveService
{
    private SqlServerContext _context;
    private DbSet<Reserve> _dataset;
    private IRepository<Reserve> _repository;
    private readonly ReserverConvert _converter;

    public ReserveServiceImpl(SqlServerContext context, IRepository<Reserve> repository)
    {
        _context = context;
        _dataset = context.Set<Reserve>();
        _repository = repository;
        _converter = new ReserverConvert();
    }
    public ReserveResponseDTO Create(ReserveDTO reserve)
    {
        var NewReserve = _converter.Parse(reserve);
        if (NewReserve.Room == null) throw new InvalidOperationException("No exist this Room");
        if (NewReserve.Status != ReserverStatus.Active) throw new InvalidOperationException("No to alter this variables");
        if(NewReserve.StartOfReserve > NewReserve.EndOfReserve) throw new InvalidTimeZoneException("Hour start of reserver not is up this hour end of reserver");
        if(NewReserve.NeedProjector != NewReserve.Room.Projector || NewReserve.Room.Capacity >= NewReserve.RequiredCapacity) throw new InvalidOperationException("Without some of the requirements");
        NewReserve = _repository.Create(NewReserve);
        return _converter.Parse(NewReserve);
    }
    public ReserveResponseDTO FindById(long id)
    {
        return _converter.Parse(_repository.FindById(id));
    }
    public List<ReserveResponseDTO> FindList(int pageNumber = 1)
    {
        return _converter.ParseList(_repository.FindList(pageNumber));
    }
    public List<ReserveResponseDTO> FindByRoomId(long roomId, int pageNumber = 1)
    {
        var aux = _dataset.Where(x => x.RoomId == roomId).Skip((pageNumber - 1) * 15).Take(15).ToList();
        return _converter.ParseList(aux);
    }
    public List<ReserveResponseDTO> FindByPeriod(ReserverPeriodFilterDTO filter)
    {
        var aux = _dataset.Where(x => (filter.Start >= x.StartOfReserve) || (filter.Start < x.EndOfReserve) ).Skip((filter.PageNumber - 1) * 15).Take(15).ToList();
        return _converter.ParseList(aux);
    }
    public void Canceled(long id)
    {
        var aux = _repository.FindById(id);
        if (aux == null) return;
        if (aux.Status != ReserverStatus.Active) throw new InvalidOperationException("It is only possible to cancel a reservation if it is in active status");
        aux.Status = ReserverStatus.Canceled;
        _repository.Update(aux);
    }
    public void Completed(long id)
    {
        var aux = _repository.FindById(id);
        if (aux == null) return;
        if (aux.Status != ReserverStatus.Active) throw new InvalidOperationException("It is only possible to complede a reservation if it is in active status");
        aux.Status = ReserverStatus.Completed;
        _repository.Update(aux);
    }
    public void Delete(long id)
    {
        var aux = _repository.FindById(id);
        if (aux == null) return;
        if (aux.Status != ReserverStatus.Active) _repository.Delete(id);
        else throw new InvalidOperationException("It is only possible to delete a reservation if it is in canceled or completed status");
    }
}
