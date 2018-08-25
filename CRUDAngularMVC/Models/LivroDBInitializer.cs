using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDAngularMVC.Models
{
    public class LivroDBInitializer : CreateDatabaseIfNotExists<LivroContexto>
    {
        protected override void Seed(LivroContexto context)
        {
            IList<Livro> dados = new List<Livro>();

            dados.Add(new Livro()
            {
                Autor = "Gustavo Cerbasi",
                Editor = "Gustavo Cerbasi",
                Isbn = "124568527698",
                Titulo = "Como organizar sua vida financeira"
            });
            dados.Add(new Livro()
            {
                Autor = "Gustavo Cerbasi",
                Editor = "Gustavo Cerbasi",
                Isbn = "9638527410023",
                Titulo = "Casais inteligentes enriquecem juntos"
            });

            dados.Add(new Livro()
            {
                Autor = "Jane Hawking",
                Editor = "Jane Hawking",
                Isbn = "0023587945612",
                Titulo = "A teoria de tudo"
            });

            dados.Add(new Livro()
            {
                Autor = "George R. R. Martin",
                Editor = "George R. R. Martin",
                Isbn = "789852746320158",
                Titulo = "A guerra dos tronos: O festim dos corvos"
            });

            dados.Add(new Livro()
            {
                Autor = "Dan Brown",
                Editor = "Dan Brown",
                Isbn = "023579455630",
                Titulo = "Ponto de impacto"
            });

            foreach (Livro livro in dados)
            {
                context.Livro.Add(livro);
            }

            base.Seed(context);
        }
    }
}