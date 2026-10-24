using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechNova.Api.Data.DTO;
using TechNova.Api.Services;

namespace MyApp.Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class ReserverController : ControllerBase
    {
        private IReserveService _reserveService;
        private readonly ILogger<ReserverController> _logger;
        public ReserverController(IReserveService reserveService, ILogger<ReserverController> logger)
        {
            _reserveService = reserveService;
            _logger = logger;
        }

        [HttpGet("FindL/{pageNumber}")]
        public IActionResult Get(int pageNumber)
        {
            _logger.LogInformation("Fetching all Reservations");
            return Ok(_reserveService.FindList(pageNumber));
        }

        [HttpGet("FindID/{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching reserver with id: {id}", id);
            var reserver = _reserveService.FindById(id);
            if (reserver == null)
            {
                _logger.LogWarning("Reserver with ID {id} not found", id);
                return NotFound();
            }
            return Ok(reserver);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReserveDTO reserve)
        {
            _logger.LogInformation("Create new reserve: {NameEmployee}", reserve.EmployeeName);
            try
            {
                var createNewReserve = _reserveService.Create(reserve);
                return Ok(createNewReserve);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to create reserve: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FindL/{roomId}/{pageNumber}")]
        public IActionResult Get(long roomId, int pageNumber)
        {
            _logger.LogInformation("Fetching all Reservers with room id {roomId}", roomId);
            return Ok(_reserveService.FindByRoomId(roomId, pageNumber));
        }

        [HttpGet("FindL")]
        public IActionResult Get([FromBody] ReserverPeriodFilterDTO filter)
        {
            _logger.LogInformation("Fetching all Reservers the period hour digit");
            try
            {
                var listReserve = _reserveService.FindByPeriod(filter);
                return Ok(listReserve);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to source list {mesage}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Canceled/{id}")]
        public IActionResult PutCanceled(long id)
        {
            _logger.LogInformation("Fecching reserve with id is {id} for canceled Status", id);
            try
            {
                _reserveService.Canceled(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning("Not found reserve with id {id}, {message}", id, ex.Message);
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to Canceled: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Completed/{id}")]
        public IActionResult PutCompleted(long id)
        {
            _logger.LogInformation("Fecching reserve with id is {id} for completed Status", id);
            try
            {
                _reserveService.Completed(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning("Not found reserve with id {id}: {message}", id, ex.Message);
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to Completed: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Fecching reserve with id is {id} for delete reserve", id);
            try
            {
                _reserveService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning("Not found reserve with id {id}: {message}", id, ex.Message);
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning("Failed to Deleted: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}