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
using api.ViewModel;

namespace api.Controllers
{
    [ApiController, Route("api/enderecos")]
    public class EnderecosController : Controller
    {
        private readonly apiContext _context;
        private readonly IServiceProvider _provider;

        public EnderecosController(apiContext context, IServiceProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        // GET: api/Enderecos
        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            var enderecos = await _context.Endereco.ToListAsync();

            return new EnderecoListJson(enderecos, enderecos.Count);
        }

        // GET: api/Enderecos/5
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetEndereco([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }

        // PUT: api/Enderecos/5
        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EnderecoModel model)
        {
            var service = _provider.GetRequiredService<EnderecoManagement>();

            if(!await service.UpdateAsync(id, model.Map()))
            {
                return BadRequest();
            }

            return new JsonResult(service.Endereco);
        }

        // POST: api/Enderecos
        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([FromBody] EnderecoModel model)
        {
            var service = _provider.GetRequiredService<EnderecoManagement>();

            if(! await service.AddAsync(model.Map()))
            {
                return BadRequest();
            }

            return new JsonResult(service.Endereco);
        }

        // DELETE: api/Enderecos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();

            return Ok(endereco);
        }

        private bool EnderecoExists(int id)
        {
            return _context.Endereco.Any(e => e.Id == id);
        }
    }
}