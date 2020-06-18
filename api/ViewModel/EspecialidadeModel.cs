using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class EspecialidadeModel
    {
        public string Descricao { get; set; }

        public Especialidade Map()
        {
            return new Especialidade
            {
                Descricao = Descricao
            };
        }
    }
}
