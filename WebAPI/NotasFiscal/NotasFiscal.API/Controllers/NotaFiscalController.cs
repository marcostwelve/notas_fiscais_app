using Microsoft.AspNetCore.Mvc;
using NotaFiscal.Application.Services.Interfaces;

namespace NotasFiscal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly IBuscaNotaService _buscaNotaService;
        public NotaFiscalController(IBuscaNotaService buscaNotaService)
        {
            _buscaNotaService = buscaNotaService;
        }
        [HttpGet("notas-por-mes")]
        public async Task<IActionResult> BuscarNotaFiscalPorMes([FromQuery] int mes)
        {
           try
           {
                var notasFiscais = await _buscaNotaService.BuscarNotasPorMes(mes);
                return Ok(notasFiscais);
           }
           catch (Exception ex)
           {
                return NotFound( ex.Message);
           }
        }
    }
}
