using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ProximaFase.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.Preferencias> Preferencias { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.ConsoleGame> ConsoleGames { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.Endereco> Enderecoes { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.Mensagem> Mensagems { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.Combinacao> Combinacaos { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.JogoPossuido> JogosPossuidos { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.JogoDesejado> JogosDesejados { get; set; }

        public System.Data.Entity.DbSet<ProximaFase.Models.Log> Logs { get; set; }


        public override int SaveChanges()
        {
            // Detecta as alterações existentes na instância corrente do DbContext.
            this.ChangeTracker.DetectChanges();
            // Identifica as entidades que devem gerar registros em log.
            var entries = DetectEntries();
            // Cria lista para armazenamento temporário dos registros em log.
            List<Log> logs = new List<Log>(entries.Count());
            // Varre as entidades que devem gerar registros em log.
            foreach (var entry in entries)
            {
                // Cria novo registro de log.
                Log newLog = GetLog(entry);

                if (newLog != null)
                    logs.Add(newLog);
            }
            // Adiciona os registros de log na fonte de dados.
            foreach (var item in logs)
            {
                this.Entry(item).State = EntityState.Added;
            }
            // Persiste as informações na fonte de dados.
            return base.SaveChanges();
        }


        /// <summary>
        /// Identifica quais entidades devem ser gerar registros de log.
        /// </summary>
        private IEnumerable<DbEntityEntry> DetectEntries()
        {
            return ChangeTracker.Entries().Where(e => (e.State == EntityState.Modified ||
                                                        e.State == EntityState.Added ||
                                                        e.State == EntityState.Deleted) &&
                                                        e.Entity.GetType() != typeof(Log));
        }

        /// <summary>
        /// Cria os registros de log.
        /// </summary>
        private Log GetLog(DbEntityEntry entry)
        {

            Log returnValue = null;

            if (entry.State == EntityState.Added)
            {
                returnValue = GetInsertLog(entry);
            }
            else if (entry.State == EntityState.Modified)
            {
                returnValue = GetUpdateLog(entry);
            }
            else if (entry.State == EntityState.Deleted)
            {
                returnValue = GetDeleteLog(entry);
            }

            return returnValue;
        }

        private Log GetInsertLog(DbEntityEntry entry)
        {
            return Log.CreateInsertLog(entry.Entity);
        }

        private Log GetDeleteLog(DbEntityEntry entry)
        {
            return Log.CreateDeleteLog(entry.Entity);
        }

        private Log GetUpdateLog(DbEntityEntry entry)
        {
            object originalValue = null;

            if (entry.OriginalValues != null)
                originalValue = entry.OriginalValues.ToObject();
            else
                originalValue = entry.GetDatabaseValues().ToObject();

            return Log.CreateUpdateLog(originalValue, entry.Entity);
        }
    }
}
