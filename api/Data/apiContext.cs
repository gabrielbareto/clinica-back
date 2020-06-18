using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class apiContext : DbContext
    {
        public apiContext (DbContextOptions<apiContext> options)
            : base(options)
        {
        }

        public DbSet<api.Models.Cobertura> Cobertura { get; set; }

        public DbSet<api.Models.Consulta> Consulta { get; set; }

        public DbSet<api.Models.Endereco> Endereco { get; set; }

        public DbSet<api.Models.Especialidade> Especialidade { get; set; }

        public DbSet<api.Models.Medico> Medico { get; set; }

        public DbSet<api.Models.Paciente> Paciente { get; set; }

        public DbSet<api.Models.Receita> Receita { get; set; }

        public DbSet<api.Models.Requisicao> Requisicao { get; set; }
    }
}
