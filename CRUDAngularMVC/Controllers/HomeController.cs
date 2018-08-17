using CRUDAngularMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDAngularMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            using (LivroContexto context = new LivroContexto())
            {
                try
                {
                    var listaLivros = context.Livro.ToList();
                    return Json(listaLivros, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public JsonResult GetById(int id)
        {
            using (LivroContexto db = new LivroContexto())
            {
                var livro = db.Livro.Find(id);
                return Json(livro, JsonRequestBehavior.AllowGet);
            }
        }

        public string AtualizadorLivro(Livro context)
        {
            if (context != null)
            {
                using (LivroContexto db = new LivroContexto())
                {
                    int _id = Convert.ToInt32(context.Id);
                    Livro _livro = db.Livro.Where(c => c.Id == _id).FirstOrDefault();
                    _livro.Titulo = context.Titulo;
                    _livro.Autor = context.Autor;
                    _livro.Editor = context.Editor;
                    _livro.Isbn = context.Isbn;

                    db.Livro.Add(_livro);
                    db.SaveChanges();

                    return "Registro atualizado com sucesso.";
                }
            }
            else
            {
                return "Registro de livro inválido.";
            }
        }

        public string AdicionarLivro(Livro livro)
        {
            if (livro != null)
            {
                using (LivroContexto _db = new LivroContexto())
                {
                    try
                    {
                        _db.Livro.Add(livro);
                        _db.SaveChanges();
                        return "Registro adcionado com sucesso.";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                return "Regitro - Bloqueado/Desbloqueaco.";
            }
        }

        public string Deletar(string livroId)
        {
            if (!String.IsNullOrWhiteSpace(livroId))
            {
                try
                {
                    int id = Convert.ToInt32(livroId);
                    using (LivroContexto db = new LivroContexto())
                    {
                        var _livro = db.Livro.Find(id);
                        db.Livro.Remove(_livro);
                        db.SaveChanges();

                        return "Registro de livro excluído com sucesso.";
                    }

                }
                catch (Exception)
                {
                    return "Detalhes do livro não encontrados.";
                }
            }
            else
            {
                return "Operação inválida.";
            }
        }
    }
}