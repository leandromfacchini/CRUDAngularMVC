using System.Data.Entity;

namespace CRUDAngularMVC.Models
{
    public class LivroContexto : DbContext
    {
        public LivroContexto() : base("name=connection")
        {
            Database.SetInitializer<LivroContexto>(new LivroDBInitializer());
        }

        public DbSet<Livro> Livro { get; set; }
    }
}