using BibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            //
            List<Categoria> categorias = _context.Categorias.ToList();
            if(categorias.Count > 0)
            {
                return View(categorias);
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria model)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria model = _context.Categorias.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Categoria model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(model).State = 
                        System.Data.Entity.EntityState.Modified;

                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = _context.Categorias.Find(Id);
            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Categoria categoria = _context.Categorias.Find(Id);

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public string GetCategoriaByNome(int IdCategoria)
        {
            var result = _context.Categorias.Find(IdCategoria);
            var nome = result.Nome;

            return nome;
        }
    }
}
