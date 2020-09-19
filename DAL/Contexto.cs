using Microsoft.EntityFrameworkCore;
using RegistroBlazor.Models;
using System;

namespace RegistroBlazor.DAL
{
    public class Contexto : DbContext
    {
        
       
        public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Registro.db");
        }

       
    }
}

