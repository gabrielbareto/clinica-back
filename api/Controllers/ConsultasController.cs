using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.ResultModel;
using api.ServiceModel;
using Microsoft.Extensions.DependencyInjection;

namespace api.Controllers
{
    [ApiController, Route("api/consultas")]
    public class ConsultasController : Controller
    {
        private readonly apiContext _context;
        private readonly IServiceProvider _provider;

        public ConsultasController(apiContext context, IServiceProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        // GET: api/Consultas
        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            var consultas = await _context.Consulta.ToListAsync();

            return new ConsultaListJson(consultas, consultas.Count);
        }

        // GET: api/Consultas/5
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetConsulta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consulta = await _context.Consulta.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta);
        }

        // PUT: api/Consultas/5
        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Consulta model)
        {
            var service = _provider.GetRequiredService<ConsultaManagement>();

            if(!await service.UpdateAsync(id, model.Map()))
            {
                return BadRequest();
            }

            return new JsonResult(service.Consulta);
        }

        // POST: api/Consultas
        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody] Consulta model)
        {
            var service = _provider.GetRequiredService<ConsultaManagement>();

            if(!await service.AddAsync(model.Map()))
            {
                return BadRequest();
            }

            return new JsonResult(service.Consulta);
        }
        /*
        // DELETE: api/Consultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _context.Consulta.Remove(consulta);
            await _context.SaveChangesAsync();

            return Ok(consulta);
        }
        
        private bool ConsultaExists(int id)
        {
            return _context.Consulta.Any(e => e.Id == id);
        }
        */
    }
}