using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ServiceModel
{
    public class EspecialidadeManagement
    {
        private readonly apiContext _context;

        public Especialidade Especialidade { get; set; }

        public EspecialidadeManagement(apiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Especialidade especialidade)
        {
            Especialidade = especialidade;

            _context.Especialidade.Add(Especialidade);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Especialidade especialidade)
        {
            Especialidade = _context.Especialidade.SingleOrDefault(x => x.Id == id);

            if (Especialidade == null) return false;

            Especialidade.Descricao = especialidade.Descricao;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
