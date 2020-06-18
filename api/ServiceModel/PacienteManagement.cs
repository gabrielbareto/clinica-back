using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ServiceModel
{
    public class PacienteManagement
    {
        private readonly apiContext _context;

        public Paciente Paciente { get; set; }

        public PacienteManagement(apiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Paciente paciente)
        {
            Paciente = paciente;

            _context.Paciente.Add(Paciente);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Paciente paciente)
        {
            Paciente = _context.Paciente.SingleOrDefault(x => x.Id == id);

            if (Paciente == null) return false;

            Paciente.Nome = paciente.Nome;
            Paciente.Nascimento = paciente.Nascimento;
            Paciente.Telefone = paciente.Telefone;
            Paciente.Rg = paciente.Rg;
            Paciente.Cpf = paciente.Cpf;
            Paciente.EnderecoId = paciente.EnderecoId;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
