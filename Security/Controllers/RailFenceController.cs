using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.DTOs.Monoalphabetic;
using Security.DTOs.RailFence;
using Security.Services;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RailFenceController(IRailFenceService railFenceService) : ControllerBase
    {
        private readonly IRailFenceService _railFenceService = railFenceService;
        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] RailFenceRequest request)
        {
            return Ok(_railFenceService.Encrypt(request));
        }

        [HttpPost("decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] RailFenceRequest request)
        {
            return Ok(_railFenceService.Decrypt(request));
        }
    }
}
