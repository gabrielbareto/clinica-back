using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModel
{
    public class EnderecoModel
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco Map()
        {
            return new Endereco
            {
                Rua = Rua,
                Bairro = Bairro,
                Numero = Numero,
                Cidade = Cidade,
                Estado = Estado
            };
        }
    }
}
