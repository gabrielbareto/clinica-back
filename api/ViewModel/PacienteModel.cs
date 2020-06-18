using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class PacienteModel
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public int EnderecoId { get; set; }

        public Paciente Map()
        {
            return new Paciente
            {
                Nome = Nome,
                Nascimento = Nascimento,
                Telefone = Telefone,
                Rg = Rg,
                Cpf = Cpf,
                EnderecoId = EnderecoId
            };
        }
    }
}
