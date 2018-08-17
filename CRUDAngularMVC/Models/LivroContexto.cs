using System.Data.Entity;

namespace CRUDAngularMVC.Models
{
    public class LivroContexto : DbContext
    {
        public DbSet<Livro> Livro { get; set; }
    }
}