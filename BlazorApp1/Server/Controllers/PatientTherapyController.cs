using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTherapyController : ControllerBase
    {
            
        private readonly IGenericRepository<PatientTherapy> _repository;

        public PatientTherapyController(IGenericRepository<PatientTherapy> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientTherapy patientTherapy)
        {
            if (patientTherapy == null)
            {
                return BadRequest("PatientTherapy is null.");
            }

            try
            {
                await _repository.AddAsync(patientTherapy);
                return CreatedAtAction(nameof(GetPatientTherapyById), new { id = patientTherapy.Id }, patientTherapy);
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
            var patientTherapies = await _repository.GetAllAsync();
            return Ok(patientTherapies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientTherapy>> GetPatientTherapyById(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientTherapy patientTherapy)
        {
            if (patientTherapy == null || patientTherapy.Id != id)
            {
                return BadRequest("Patient ID mismatch.");
            }

            try
            {
                await _repository.UpdateAsync(patientTherapy);
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
        public async Task<ActionResult<IEnumerable<PatientTherapy>>> Search([FromQuery] string roomNumber)
        {
            var rooms = await _repository.FindAsync(p => p.Patient.FullName.Contains(roomNumber));
            return Ok(rooms);


        }
    }
}
