using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ServiceModel
{
    public class RequisicaoManagement
    {
        private readonly apiContext _context;

        public Requisicao Requisicao { get; set; }

        public RequisicaoManagement(apiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Requisicao requisicao)
        {
            Requisicao = requisicao;

            _context.Requisicao.Add(Requisicao);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Requisicao requisicao)
        {
            Requisicao = _context.Requisicao.SingleOrDefault(x => x.Id == id);

            if (Requisicao == null) return false;

            Requisicao.Descricao = requisicao.Descricao;
            Requisicao.PacienteId = requisicao.PacienteId;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
