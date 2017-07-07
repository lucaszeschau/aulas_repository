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
    public class OperacoesController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly LivrosController _livroController = new LivrosController();
        private readonly ClientesController _clienteController = new ClientesController(); 

        public ActionResult Index()
        {
            List<Operacao> op = _context.Operacoes.ToList();
            if (op.Count > 0)
            {
                return View(op);
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

            Operacao model = _context.Operacoes.Find(Id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            #region [Livros]

            var liv = from l in _context.Livros
                          where l.Disponivel == true
                          orderby l.Nome
                          select new { l.Id, l.Nome };

            var livros = liv.ToList().Select(m => new SelectListItem
            {
                Text = m.Nome,
                Value = m.Id.ToString()
            }).ToList();

            ViewBag.Livros = livros;

            #endregion

            #region [Clientes]

            var cli = from c in _context.Clientes
                      where c.Status == true
                      orderby c.Nome
                      select new { c.Id, c.Nome };

            var clientes = cli.ToList().Select(m => new SelectListItem
            {
                Text = m.Nome,
                Value = m.Id.ToString()
            }).ToList();

            ViewBag.Clientes = clientes;

            #endregion

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Operacao model)
        {
            if (ModelState.IsValid)
            {
                model.Status = true;
                model.DataDevolucao = null;
                model.DataPrevisao = model.DataEmprestimo.AddDays(7);

                _livroController.UpdateStatusEmprestimo(model.IdLivro);
                _context.Operacoes.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public void UpdateOperacoes(int? Id)
        {
            var model = _context.Operacoes.Find(Id);

            if (model != null)
            {
                model.Status = false;
                model.DataDevolucao = DateTime.Today;

                _livroController.UpdateStatusDevolucao(model.IdLivro);
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
