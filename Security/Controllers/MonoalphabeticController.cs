using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.DTOs.Caesar;
using Security.DTOs.Monoalphabetic;
using Security.Services;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonoalphabeticController(IMonoalphabeticService monoalphabeticService) : ControllerBase
    {
        private readonly IMonoalphabeticService _monoalphabeticService = monoalphabeticService;

        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] monoalphabeticRequest request)
        {
            return Ok(_monoalphabeticService.Encrypt(request));
        }

        [HttpPost("decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] monoalphabeticRequest request)
        {
            return Ok(_monoalphabeticService.Decrypt(request));
        }
    }
}
