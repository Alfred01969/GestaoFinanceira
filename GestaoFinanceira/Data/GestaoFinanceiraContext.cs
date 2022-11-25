using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoFinanceira.Models;

namespace GestaoFinanceira.Data
{
    public class GestaoFinanceiraContext : DbContext
    {
        public GestaoFinanceiraContext (DbContextOptions<GestaoFinanceiraContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoFinanceira.Models.Registro> Registro { get; set; } = default!;

        public DbSet<GestaoFinanceira.Models.Tipo> Tipo { get; set; }
    }
}
