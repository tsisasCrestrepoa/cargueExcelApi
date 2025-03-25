using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using PruebaCargueExcel;
using DataAccess.Repository;

namespace PruebaCargueExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly PruebaCargueExcelContext context;
        private readonly GenericEntity<TipoIdentificacion> _TipoIdentificacion;
        

        public TipoIdentificacionController(PruebaCargueExcelContext _context, GenericEntity<TipoIdentificacion> genericEntity)
        {
            context = _context;
            _TipoIdentificacion = genericEntity;
           
        }

        // GET: api/TipoIdentificacion
        [HttpGet]
        public async Task<ActionResult> GetTipoIdentificacion()
        {
            var lista = await _TipoIdentificacion.GetAll();
            return Ok(lista);
        }

        // GET: api/TipoIdentificacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIdentificacion>> GetTipoIdentificacion(int id)
        {
            var tipoIdentificacion = await context.TipoIdentificacion.FindAsync(id);

            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            return tipoIdentificacion;
        }

        // PUT: api/TipoIdentificacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIdentificacion(int id, TipoIdentificacion tipoIdentificacion)
        {
            if (id != tipoIdentificacion.Id)
            {
                return BadRequest();
            }

            context.Entry(tipoIdentificacion).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIdentificacionExists(id))
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

        // POST: api/TipoIdentificacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("multipart/form-data")]
        public ActionResult<TipoIdentificacion> LoadFile( IFormFile Archivo )
        {
            
            return Ok();
            
            //context.TipoIdentificacion.Add(tipoIdentificacion);
            //await context.SaveChangesAsync();

            //return CreatedAtAction("GetTipoIdentificacion", new { id = tipoIdentificacion.Id }, tipoIdentificacion);
        }

        // DELETE: api/TipoIdentificacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoIdentificacion(int id)
        {
            var tipoIdentificacion = await context.TipoIdentificacion.FindAsync(id);
            if (tipoIdentificacion == null)
            {
                return NotFound();
            }

            context.TipoIdentificacion.Remove(tipoIdentificacion);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoIdentificacionExists(int id)
        {
            return context.TipoIdentificacion.Any(e => e.Id == id);
        }
    }
}
