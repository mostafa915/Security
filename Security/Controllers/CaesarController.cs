using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Abstractions;
using Security.DTOs.Caesar;
using Security.Services;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaesarController(ICaesarService caesarService) : ControllerBase
    {
        private readonly ICaesarService _caesarService = caesarService;

        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] CaesarRequest request)
        {
            return Ok(_caesarService.Encrypt(request));
        }

        [HttpPost("decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] CaesarRequest request)
        {
            return Ok(_caesarService.Decrypt(request));
        }
    }
}
