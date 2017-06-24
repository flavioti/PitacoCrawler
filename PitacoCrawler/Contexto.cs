using PitacoCrawler.Models;
using System.Data.Entity;

namespace PitacoCrawler
{
    public class Contexto: System.Data.Entity.DbContext
    {
        public Contexto(): base("ConexaoMySQL")
        {

        }

        public DbSet<Resultado> Resultado { get; set; }

    }
}
