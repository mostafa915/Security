using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.DTOs.RowTransposition;
using Security.DTOs.Vigenere;
using Security.Services;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowTranspositionController(IRowTranspositionService rowTranspositionService) : ControllerBase
    {
        private readonly IRowTranspositionService _rowTranspositionService = rowTranspositionService;

        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody] RowTranspositionRequest request)
        {
            return Ok(_rowTranspositionService.Encrypt(request));
        }

        [HttpPost("decrypt")]
        public async Task<IActionResult> Decrypt([FromBody] RowTranspositionRequest request)
        {
            return Ok(_rowTranspositionService.Decrypt(request));
        }
    }
}
