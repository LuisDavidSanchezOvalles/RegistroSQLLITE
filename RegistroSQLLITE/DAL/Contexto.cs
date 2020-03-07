using System;
using System.Collections.Generic;
using System.Text;
using RegistroSQLLITE.Entidades;
using Microsoft.EntityFrameworkCore;

namespace RegistroSQLLITE.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = PersonasSQLLITE.db");
        }
    }
}
