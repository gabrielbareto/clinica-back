using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
