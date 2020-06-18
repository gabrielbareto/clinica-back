using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int CoberturaId { get; set; }
        public Cobertura Cobertura { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
        public int RequisicaoId { get; set; }
        public Requisicao Requisicao { get; set; }

        internal Consulta Map()
        {
            throw new NotImplementedException();
        }
    }
}
