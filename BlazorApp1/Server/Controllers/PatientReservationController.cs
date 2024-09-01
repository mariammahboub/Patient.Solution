using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientReservationController : ControllerBase
    {
            
        private readonly IGenericRepository<PatientReservation> _repository;

        public PatientReservationController(IGenericRepository<PatientReservation> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientReservation patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient is null.");
            }

            try
            {
                await _repository.AddAsync(patient);
                return CreatedAtAction(nameof(GetPatientReservationById), new { id = patient.Id }, patient);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientReservation>>> GetAll()
        {
            var reservations = await _repository.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientReservation>> GetPatientReservationById(int id)
        {
            var reservation = await _repository.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientReservation reservation)
        {
            if (reservation == null || reservation.Id != id)
            {
                return BadRequest("Patient ID mismatch.");
            }

            try
            {
                await _repository.UpdateAsync(reservation);
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
        public async Task<ActionResult<IEnumerable<PatientReservation>>> Search([FromQuery] string name)
        {
            var rooms = await _repository.FindAsync(p => p.Patient.FullName.Contains(name));
            return Ok(rooms);


        }
    }
}
