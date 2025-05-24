using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdquisicionesBackend.Data;
using AdquisicionesBackend.Models;
using AdquisicionesBackend.Data;

namespace AdquisicionesBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RequerimientoAdquisicionesController : ControllerBase
  {
    private readonly AppDbContext _context;

    public RequerimientoAdquisicionesController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/RequerimientoAdquisiciones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RequerimientoAdquisicion>>> GetRequerimientoAdquisiciones()
    {
      return await _context.RequerimientosAdquisicion.ToListAsync();
    }

    // GET: api/RequerimientoAdquisiciones/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RequerimientoAdquisicion>> GetRequerimientoAdquisicion(int id)
    {
      var requerimiento = await _context.RequerimientosAdquisicion.FindAsync(id);

      if (requerimiento == null)
      {
        return NotFound();
      }

      return requerimiento;
    }

    // POST: api/RequerimientoAdquisiciones
    [HttpPost]
    public async Task<ActionResult<RequerimientoAdquisicion>> PostRequerimientoAdquisicion(RequerimientoAdquisicion RequerimientoAdquisicion)
    {
      _context.RequerimientosAdquisicion.Add(RequerimientoAdquisicion);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetRequerimientoAdquisicion), new { id = RequerimientoAdquisicion.Id }, RequerimientoAdquisicion);
    }

    // POST: api/RequerimientoAdquisiciones
    [HttpPost("ActivarInactivarRequerimiento/{id}")]
    public async Task<ActionResult<RequerimientoAdquisicion>> ActivarInactivarRequerimiento(int id)
    {
      if (id <= 0)
      {
        return BadRequest();
      }

      var requerimiento = _context.RequerimientosAdquisicion.FirstOrDefault(r => r.Id == id);
      if (requerimiento == null)
      {
        return BadRequest();
      }
      else
      {
        requerimiento.Activo = !requerimiento.Activo;
      }
      var requerimientoOriginal = _context.RequerimientosAdquisicion.AsNoTracking().FirstOrDefault(r => r.Id == id);
      _context.RequerimientoAdquisicionHistoricos.Add(new RequerimientoAdquisicionHistorico
      {
        Activo = requerimientoOriginal.Activo,
        Cantidad = requerimientoOriginal.Cantidad,
        FechaAdquisicion = requerimientoOriginal.FechaAdquisicion,
        FechaModificacion = DateTime.Now,
        IdRequerimientoAdquisicion = requerimientoOriginal.Id,
        Presupuesto = requerimientoOriginal.Presupuesto,
        TipoBien = requerimientoOriginal.TipoBien,
        Proveedor = requerimientoOriginal.Proveedor,
        Unidad = requerimientoOriginal.Unidad,
        ValorTotal = requerimientoOriginal.ValorTotal,
        ValorUnitario = requerimientoOriginal.ValorUnitario
      });
      try
        {
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!RequerimientoAdquisicionExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }

      return NoContent();
    }

    // PUT: api/RequerimientoAdquisiciones/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRequerimientoAdquisicion(int id, RequerimientoAdquisicion RequerimientoAdquisicion)
    {
      if (id != RequerimientoAdquisicion.Id)
      {
        return BadRequest();
      }

      var requerimientoOriginal = _context.RequerimientosAdquisicion.AsNoTracking().FirstOrDefault(r => r.Id == id);
      _context.RequerimientoAdquisicionHistoricos.Add(new RequerimientoAdquisicionHistorico
      {
        Activo = requerimientoOriginal.Activo,
        Cantidad = requerimientoOriginal.Cantidad,
        FechaAdquisicion = requerimientoOriginal.FechaAdquisicion,
        FechaModificacion = DateTime.Now,
        IdRequerimientoAdquisicion = requerimientoOriginal.Id,
        Presupuesto = requerimientoOriginal.Presupuesto,
        TipoBien = requerimientoOriginal.TipoBien,
        Proveedor = requerimientoOriginal.Proveedor,
        Unidad = requerimientoOriginal.Unidad,
        ValorTotal = requerimientoOriginal.ValorTotal,
        ValorUnitario = requerimientoOriginal.ValorUnitario
      });
      _context.Entry(RequerimientoAdquisicion).State = EntityState.Modified;

      try
      {
       

        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RequerimientoAdquisicionExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool RequerimientoAdquisicionExists(int id)
    {
      return _context.RequerimientosAdquisicion.Any(e => e.Id == id);
    }
  }
}
