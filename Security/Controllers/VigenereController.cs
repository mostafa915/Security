using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.DTOs.Caesar;
using Security.DTOs.Vigenere;
using Security.Services;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VigenereController(IVigenereService vigenereService) : ControllerBase
    {
        private readonly IVigenereService _vigenereService = vigenereService;

        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] VigenereRequest request)
        {
            return Ok(_vigenereService.Encrypt(request));
        }

        [HttpPost("decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] VigenereRequest request)
        {
            return Ok(_vigenereService.Decrypt(request));
        }
    }
}
