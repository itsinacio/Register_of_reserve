using System.Reflection;
using TechNova.Api.Data.Converter.Impl;
using TechNova.Api.Data.DTO;
using TechNova.Api.Model;
using TechNova.Api.Model.Enum;
using TechNova.Api.Repositories;

namespace TechNova.Api.Services.Impl;

public class ReserveServiceImpl : IReserveService
{
    private IRepository<Reserve> _repository;
    private IRepository<Room> _repository2;
    private readonly ReserverConvert _converter;

    public ReserveServiceImpl(IRepository<Reserve> repository,  IRepository<Room> repository2)
    {
        _repository = repository;
        _repository2 = repository2;
        _converter = new ReserverConvert();
    }
    public ReserveResponseDTO Create(ReserveDTO reserve)
    {
        if(_repository2.FindById(reserve.RoomId) == null) throw new InvalidOperationException("No exist this Room");
        if (reserve.Status != ReserverStatus.Active) throw new InvalidOperationException("No to alter this variables");
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
        throw new NotImplementedException();
    }
    public List<ReserveResponseDTO> FindByPeriod(ReserverPeriodFilterDTO filter)
    {
        throw new NotImplementedException();
    }
    public void Canceled (long id)
    {
        var aux = _repository.FindById(id);
        if(aux == null) return ;
        if(aux.Status != ReserverStatus.Active) throw new InvalidOperationException("It is only possible to cancel a reservation if it is in active status");
        aux.Status = ReserverStatus.Canceled;
        _repository.Update(aux);
    }
    public void Completed (long id)
    {
        var aux = _repository.FindById(id);
        if(aux == null) return ;
        if(aux.Status != ReserverStatus.Active) throw new InvalidOperationException("It is only possible to complede a reservation if it is in active status");
        aux.Status = ReserverStatus.Completed;
        _repository.Update(aux);
    }
    public ReserveResponseDTO UpdateReserve(ReserveDTO reserve)
    {
        throw new NotImplementedException();
    }
    public void Delete(long id)
    {
        var aux = _repository.FindById(id);
        if(aux == null) return ;
        if(aux.Status != ReserverStatus.Active) _repository.Delete(id);
        else throw new InvalidOperationException("It is only possible to delete a reservation if it is in canceled or completed status");
    }
}
