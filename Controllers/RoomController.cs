using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechNova.Api.Data.DTO;
using TechNova.Api.Services;

namespace MyApp.Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;
        private readonly ILogger<RoomController> _logger;
        public RoomController(IRoomService roomService, ILogger<RoomController> logger)
        {
            _roomService = roomService;
            _logger = logger;
        }

        [HttpGet("FindL/{pageNumber}")]
        public IActionResult Get(int pageNumber)
        {
            _logger.LogInformation("Fetching all Rooms");
            return Ok(_roomService.FindList(pageNumber));
        }

        [HttpGet("FindID/{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching room with id: {id}", id);
            var room = _roomService.FindById(id);
            if (room == null)
            {
                _logger.LogWarning("Room with ID {id} not found", id);
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RoomDTO room)
        {
            _logger.LogInformation("Create new Room: {NameRoom}", room.NameRoom);
            try
            {
                var createNewRoom = _roomService.Create(room);
                return Ok(createNewRoom);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to create room: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] RoomDTO room)
        {
            _logger.LogInformation("Updating room with id: {id}",room.Id);
            try
            {
                var uptadeRoom = _roomService.Update(room);
                if(uptadeRoom == null)
                {
                    _logger.LogWarning("Not found this room for uptadet");
                    return NotFound();
                }
                return Ok(uptadeRoom);
            }catch(InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to uptade room: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SetUna/{id}")]
        public IActionResult Put(long id ,[FromBody] RoomReasonDTO reason)
        {
            _logger.LogInformation("Updating room with id: {id}",id);
            try
            {
                var uptadeRoom = _roomService.SetUnavailable(id,reason);
                if(uptadeRoom == null)
                {
                    _logger.LogWarning("Not found this room for uptadet");
                    return NotFound();
                }
                return Ok(uptadeRoom);
            }catch(InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to uptade room: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SetAva/{id}")]
        public IActionResult Put(long id )
        {
            _logger.LogInformation("Updating room with id: {id}",id);
            try
            {
                var uptadeRoom = _roomService.SetAvailable(id);
                if(uptadeRoom == null)
                {
                    _logger.LogWarning("Not found this room for uptadet");
                    return NotFound();
                }
                return Ok(uptadeRoom);
            }catch(InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to uptade room: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
