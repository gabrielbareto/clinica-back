using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class CoberturaModel
    {

        public string Descricao { get; set; }

        public  Cobertura Map()
        {
            return new Cobertura
            {
                Descricao = Descricao
            };
        }

    }
}
