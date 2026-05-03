using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.DTOs.Caesar;
using Security.DTOs.Playfair;
using Security.Services;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayfairController(IPlayfairService playfairService) : ControllerBase
    {
        private readonly IPlayfairService _playfairService = playfairService;

        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] PlayfairRequest request)
        {
            return Ok(_playfairService.Encrypt(request));
        }

        [HttpPost("decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] PlayfairRequest request)
        {
            return Ok(_playfairService.Decrypt(request));
        }
    }
}
