using ProjetoLoja.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoLoja.Controller
{
    public class ProdutoController
    {
        private readonly DBLojaEntities _contexto = new DBLojaEntities();

        public void Create(Produto model)
        {
            _contexto.Produto.Add(model);
            _contexto.SaveChanges();

            return;
        }

        public void Editar(Produto model)
        {
            _contexto.Entry(model).State = EntityState.Modified;
            _contexto.SaveChanges();

            return;
        }

        public void Delete(Produto model)
        {
            _contexto.Entry(model).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        public List<Produto> ListProdutos()
        {
            return _contexto.Produto.ToList();
        }

        public Produto GetById(int Id)
        {
            return _contexto.Produto.Find(Id);
        }
    }
}