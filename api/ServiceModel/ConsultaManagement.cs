using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ServiceModel
{
    public class ConsultaManagement
    {
        private readonly apiContext _context;

        public Consulta Consulta { get; set; }

        public ConsultaManagement(apiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Consulta consulta)
        {
            Consulta = consulta;

            _context.Consulta.Add(Consulta);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Consulta consulta)
        {
            Consulta = _context.Consulta.SingleOrDefault(x => x.Id == id);

            if (Consulta == null) return false;

            Consulta.Data = consulta.Data;
            Consulta.PacienteId = consulta.PacienteId;
            Consulta.CoberturaId = consulta.CoberturaId;
            Consulta.MedicoId = consulta.MedicoId;
            Consulta.ReceitaId = consulta.ReceitaId;
            Consulta.RequisicaoId = consulta.RequisicaoId;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
