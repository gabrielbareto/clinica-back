using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel
{
    public class EnderecoListJson : IActionResult
    {
        public ICollection<Endereco> Endereco { get; set; }

        public int Count { get; set; }

        public EnderecoListJson() { }

        public EnderecoListJson(ICollection<Endereco> endereco, int count)
        {
            Endereco = endereco;
            Count = count;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
