using ProjetoLoja.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoLoja.Controller
{
    public class CategoriaController
    {
        private readonly DBLojaEntities _contexto = new DBLojaEntities();

        public void Create(Categoria model)
        {
            _contexto.Categoria.Add(model);
            _contexto.SaveChanges();

            return;
        }

        public void Editar(Categoria model)
        {
            _contexto.Entry(model).State = EntityState.Modified;
            _contexto.SaveChanges();

            return;
        }

        public void Delete(Categoria model)
        {
            _contexto.Entry(model).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        public List<Categoria> ListCategorias()
        {
            return _contexto.Categoria.ToList();
        }

        public Categoria GetById(int Id)
        {
            return _contexto.Categoria.Find(Id);
        }

        public List<Categoria> GetAllCategorias()
        {
            List<Categoria> listCategorias = new List<Categoria>();

            foreach (var item in _contexto.Categoria)
            {
                // Adiciona apenas as Categorias com status 'Ativo'
                if(item.Ativo == 1)
                    listCategorias.Add(item);
            }

            return listCategorias;
        }
    }
}