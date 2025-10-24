using EstacionamentoSenac.API.Data;
using EstacionamentoSenac.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoSenac.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Veiculo> GetVeiculos()
        {
            return _context.Veiculos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetVeiculoById(int id)
        {
            //_context.Veiculos.FirstOrDefault(v => v.Id == id);
            var veiculo = _context.Veiculos.Find(id);

            if (veiculo == null)
                return NotFound();

            return Ok(veiculo);
        }
    }
}
