using Microsoft.AspNetCore.Mvc;
using webapi.DTO;
using webapi.Model;
using webapi.Data;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilialController : Controller
    {
        private readonly AppDbContext _context;

        public FilialController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<FilialRespostaDTO>> CreateFilial(FilialDTO filialDTO)
        {
            var filial = new Filial
            {
                Nome = filialDTO.Nome,
                Endereco = filialDTO.Endereco
            };

            _context.Filiais.Add(filial);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilial), new { id = filial.Id }, filial);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilialRespostaDTO>>> GetFiliais()
        {
            var filiais = await _context.Filiais
              .Include(f => f.Areas)
              .Select(f => new FilialRespostaDTO
              {
                  Id = f.Id,
                  Nome = f.Nome,
                  Areas = f.Areas.Select(a => new AreaResumoDTO
                  {
                      Id = a.Id,
                      Status = a.Status,
                  }).ToList()
              })
            .ToListAsync();

            return filiais;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilialRespostaDTO>> GetFilial(int id)
        {
            var filial = await _context.Filiais
              .Include(f => f.Areas)
              .Where(f => f.Id == id)
              .Select(f => new FilialRespostaDTO
              {
                  Id = f.Id,
                  Nome = f.Nome,
                  Areas = f.Areas.Select(a => new AreaResumoDTO
                  {
                      Id = a.Id,
                      Status = a.Status
                  }).ToList()
            })
          .FirstOrDefaultAsync();

        if (filial == null)
        {
          return NotFound();
        }

        return filial;
    }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilial(int id, FilialDTO filialDTO)
        {
            var filial = await _context.Filiais.FindAsync(id);

            if (filial == null)
            {
                return NotFound();
            }

            filial.Nome = filialDTO.Nome;
            filial.Endereco = filialDTO.Endereco;

            _context.Entry(filial).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilial(int id)
        {
            var filial = await _context.Filiais
                .Include(f => f.Areas)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (filial == null)
            {
                return NotFound();
            }

            if (filial.Areas.Any())
            {
                return BadRequest("Não é possível deletar uma filial com áreas vinculadas");
            }

            _context.Filiais.Remove(filial);

            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
