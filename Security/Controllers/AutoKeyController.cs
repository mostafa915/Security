using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.DTOs.AutoKey;
using Security.DTOs.Caesar;
using Security.Services;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoKeyController(IAutoKeyService autoKeyService) : ControllerBase
    {
        private readonly IAutoKeyService _autoKeyService = autoKeyService;

        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] AutoKeyRequest request)
        {
            return Ok(_autoKeyService.Encrypt(request));
        }

        [HttpPost("decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] AutoKeyRequest request)
        {
            return Ok(_autoKeyService.Decrypt(request));
        }
    }
}
