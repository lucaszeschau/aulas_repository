using BibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<Livro> livros = _context.Livros.ToList();
            if (livros.Count > 0)
            {
                return View(livros);
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Livro model = _context.Livros.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var content = from c in _context.Categorias
                          where c.Status == true
                          orderby c.Nome
                          select new { c.Id, c.Nome };

            var result = content.ToList().Select(m => new SelectListItem
            {
                Text = m.Nome,
                Value = m.Id.ToString()
            }).ToList();

            ViewBag.Categorias = result;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro model)
        {
            if (ModelState.IsValid)
            {
                _context.Livros.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Livro model = _context.Livros.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            var content = from c in _context.Categorias
                          where c.Status == true
                          orderby c.Nome
                          select new { c.Id, c.Nome };

            var result = content.ToList().Select(m => new SelectListItem
            {
                Text = m.Nome,
                Value = m.Id.ToString(),
                Selected = (m.Id == model.IdCategoria)
            }).ToList();

            ViewBag.Categorias = result;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro model)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nome", model.IdCategoria);

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Livro model = _context.Livros.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Livro model = _context.Livros.Find(Id);
            _context.Livros.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public string GetLivroByTitulo(int IdLivro)
        {
            var result = _context.Livros.Find(IdLivro);
            var titulo = result.Nome;

            return titulo;
        }

        public Livro UpdateStatusEmprestimo(int IdLivro)
        {
            var livro = _context.Livros.Find(IdLivro);

            if (livro != null)
            {
                livro.Disponivel = false;
                _context.Entry(livro).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return null;
        }

        public Livro UpdateStatusDevolucao(int IdLivro)
        {
            var livro = _context.Livros.Find(IdLivro);

            if (livro != null)
            {
                livro.Disponivel = true;
                _context.Entry(livro).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
