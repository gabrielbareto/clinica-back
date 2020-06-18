using api.Data;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ServiceModel
{
    public class EnderecoManagement
    {
        private readonly apiContext _context;

        public Endereco Endereco { get; set; }

        public EnderecoManagement(apiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Endereco endereco)
        {
            Endereco = endereco;

            _context.Endereco.Add(Endereco);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, Endereco endereco)
        {
            Endereco = _context.Endereco.SingleOrDefault(x => x.Id == id);

            if (Endereco == null) return false;

            Endereco.Rua = endereco.Rua;
            Endereco.Bairro = endereco.Bairro;
            Endereco.Numero = endereco.Numero;
            Endereco.Cidade = endereco.Cidade;
            Endereco.Estado = endereco.Estado;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
