using TechNova.Api.Data.Converter.Impl;
using TechNova.Api.Data.DTO;
using TechNova.Api.Model;
using TechNova.Api.Repositories;

namespace TechNova.Api.Services.Impl;

public class RoomServiceImpl : IRoomService
{
    private IRepository<Room> _repository;
    private readonly RoomConvert _converter;

    public RoomServiceImpl(IRepository<Room> repository)
    {
        _repository = repository;
        _converter = new RoomConvert();
    }

    public RoomResponseDTO Create(RoomDTO room)
    {
        if (room.Available == false || room.UnavailabilityReason != null) throw new InvalidOperationException("No to alter this variables");
        if(room.Capacity <= 0) throw new InvalidOperationException("No exist room with capacity less than or equal to 0");
        var NewRoom = _converter.Parse(room);
        NewRoom = _repository.Create(NewRoom);
        return _converter.Parse(NewRoom);
    }
    public RoomResponseDTO FindById(long id)
    {
        return _converter.Parse(_repository.FindById(id));
    }
    public List<RoomResponseDTO> FindList(int pageNumber = 1)
    {
        return _converter.ParseList(_repository.FindList(pageNumber));
    }
    public RoomResponseDTO Update(RoomDTO room)
    {
        var aux = _repository.FindById(room.Id);
        if (aux == null) return null!;
        if(room.Capacity <= 0) throw new InvalidOperationException("No exist room with capacity less than or equal to 0");
        aux.NameRoom = room.NameRoom;
        aux.Capacity = room.Capacity;
        aux.Projector = room.Projector;
        return _converter.Parse(_repository.Update(aux));
    }
    public RoomResponseDTO SetUnavailable(long id, RoomReasonDTO reason)
    {
        var aux = _repository.FindById(id);
        if (aux == null) return null!;
        if (aux.Available == false || reason == null || string.IsNullOrEmpty(reason.Reason)) throw new InvalidOperationException("Incorrect implementation");
        aux.Available = false;
        aux.UnavailabilityReason = reason.Reason;
        _repository.Update(aux);
        return _converter.Parse(aux);
    }
    public RoomResponseDTO SetAvailable(long id)
    {
        var aux = _repository.FindById(id);
        if (aux == null) return null!;
        if (aux.Available == true) throw new InvalidOperationException("The room is now available");
        aux.Available = true;
        aux.UnavailabilityReason = null;
        _repository.Update(aux);
        return _converter.Parse(aux);
    }
}
