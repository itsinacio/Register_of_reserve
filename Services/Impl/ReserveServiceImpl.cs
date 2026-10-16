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
    private IReserverRepository _repository;
    private IRepository<Room> _repositoryRoom;
    private readonly ReserverConvert _converter;

    public ReserveServiceImpl(IReserverRepository repository, IRepository<Room> repositoryRoom)
    {
        _repository = repository;
        _repositoryRoom = repositoryRoom;
        _converter = new ReserverConvert();
    }
    public ReserveResponseDTO Create(ReserveDTO reserve)
    {
        var aux = _repositoryRoom.FindById(reserve.RoomId);
        if (aux == null) throw new InvalidOperationException("No exist this Room");
        if (reserve.Status != ReserverStatus.Active) throw new InvalidOperationException("No to alter this variables");
        if(reserve.StartOfReserve > reserve.EndOfReserve) throw new InvalidOperationException("Hour start of reserver not is up this hour end of reserver");
        if((reserve.NeedProjector && !aux.Projector) || aux.Capacity < reserve.RequiredCapacity) throw new InvalidOperationException("Without some of the requirements");
        if(ExistReserveThisHours(reserve.StartOfReserve,reserve.EndOfReserve,reserve.RoomId)) throw new InvalidOperationException("Exist reserve this hours");
        var NewReserve = _converter.Parse(reserve);
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
        return _converter.ParseList(_repository.FindByRoomId(roomId,pageNumber));
    }
    public List<ReserveResponseDTO> FindByPeriod(ReserverPeriodFilterDTO filter)
    {
        return _converter.ParseList(_repository.FindByPeriod(filter));
    }
    public void Canceled(long id)
    {
        var aux = _repository.FindById(id);
        if (aux == null) throw new KeyNotFoundException("Reserve not found");
        if (aux.Status != ReserverStatus.Active) throw new InvalidOperationException("It is only possible to cancel a reservation if it is in active status");
        aux.Status = ReserverStatus.Canceled;
        _repository.Update(aux);
    }
    public void Completed(long id)
    {
        var aux = _repository.FindById(id);
        if (aux == null) throw new KeyNotFoundException("Reserve not found");
        if (aux.Status != ReserverStatus.Active) throw new InvalidOperationException("It is only possible to complede a reservation if it is in active status");
        aux.Status = ReserverStatus.Completed;
        _repository.Update(aux);
    }
    public void Delete(long id)
    {
        var aux = _repository.FindById(id);
        if (aux == null) throw new KeyNotFoundException("Reserve not found");
        if (aux.Status != ReserverStatus.Active) _repository.Delete(id);
        else throw new InvalidOperationException("It is only possible to delete a reservation if it is in canceled or completed status");
    }
    public bool ExistReserveThisHours(DateTime Start, DateTime End, long roomId)
    {
        return _repository.ExistReserveThisHours(Start, End, roomId);
    }
}
