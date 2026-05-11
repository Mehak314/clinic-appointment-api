using ClinicAPI.Services;
using ClinicAppointmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentSystem.Controllers
{
    [ApiController]
    [Route("api/ai")]
    public class AIController : Controller
    {

        private readonly IAIService _aiService;
        public AIController(IAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("symptom-analysis")]
        public async Task<IActionResult> Analyze([FromBody] SymptomRequest request)
        {
            var result = await _aiService.AnalyzeSymptoms(request.Symptoms);

            return Ok(new
            {
                Analysis = result
            });
        }

        [HttpGet("patient-summary/{patientId}")]
        public async Task<IActionResult> GetPatientSummary(int patientId)
        {
            var result = await _aiService.GeneratePatientSummary(patientId);

            return Ok(result);
        }
    }

    public class SymptomRequest
    {
        public string Symptoms { get; set; }
    
    }
}
