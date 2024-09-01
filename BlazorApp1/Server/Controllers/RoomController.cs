using BlazorApp1.Client.Pages;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Room = Core.Models.Room;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IGenericRepository<Room> _repository;

        public RoomController(IGenericRepository<Room> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Room room)
        {
            if (room == null)
            {
                return BadRequest("Room is null.");
            }

            if (string.IsNullOrWhiteSpace(room.RoomNumber) || string.IsNullOrWhiteSpace(room.RoomFloor))
            {
                return BadRequest("Room number and floor are required.");
            }

            try
            {
                await _repository.AddAsync(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAll()
        {
            var rooms = await _repository.GetAllAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Room room)
        {
            if (room == null || room.Id != id)
            {
                return BadRequest("Patient ID mismatch.");
            }

            try
            {
                await _repository.UpdateAsync(room);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Room>>> Search([FromQuery] string roomNumber)
        {
            var rooms = await _repository.FindAsync(p => p.RoomNumber.Contains(roomNumber));
            return Ok(rooms);


        }
    }
}