using Microsoft.AspNetCore.Mvc;
using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Services;

namespace ClinicAppointmentSystem.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class VisitController : ControllerBase
        {
            private readonly IVisitService _service;

            public VisitController(IVisitService service)
            {
                _service = service;
            }

            // POST: api/visit
            [HttpPost]
            public async Task<IActionResult> Add(Visit visit)
            {
                await _service.AddVisit(visit);

                return Ok("Visit added successfully");
            }

            // GET: api/visit
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                return Ok(await _service.GetVisits());
            }

            // GET: api/visit/patient/1
            [HttpGet("patient/{patientId}")]
            public async Task<IActionResult> GetByPatient(int patientId)
            {
                var visits = await _service.GetVisitsByPatient(patientId);

                return Ok(visits);
            }
        }
    }


