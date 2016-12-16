using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProximaFase.Models
{
    public class ProximaFaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProximaFaseContext() : base("name=ProximaFaseContext")
        {
        }

        public System.Data.Entity.DbSet<ProximaFase.Models.Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ProximaFase.Models.Preferencias> Preferencias { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.ConsoleGame> ConsoleGames { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.Endereco> Enderecoes { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.Mensagem> Mensagems { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.Combinacao> Combinacaos { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.JogoPossuido> JogosPossuidos { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.JogoDesejado> JogosDesejados { get; set; }
    }
}
