﻿using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel
{
    public class RequisicaoListJson : IActionResult
    {
        public ICollection<Requisicao> Requisicao { get; set; }

        public int Count { get; set; }

        public RequisicaoListJson() { }

        public RequisicaoListJson(ICollection<Requisicao> requisicao, int count)
        {
            Requisicao = requisicao;
            Count = count;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
