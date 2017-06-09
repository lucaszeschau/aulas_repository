using ProjetoLoja.Controller;
using ProjetoLoja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoLoja.View.Produto
{
    public partial class Index : Page
    {
        private readonly DBLojaEntities _contexto = new DBLojaEntities();
        private readonly ProdutoController _controller = new ProdutoController();

        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();

            if (gridProdutos.Rows.Count > 0)
            {
                var mensagem = "Lista carregada com sucesso";
                ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + mensagem + "');", true);
            }
        }

        protected void gridProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = Convert.ToInt32(e.CommandArgument);
            int idObjeto = Convert.ToInt32(gridProdutos.Rows[linha].Cells[2].Text);
            var produto = _controller.GetById(idObjeto);

            string command = e.CommandName;
            if (command.Equals("Delete"))
            {
                _controller.Delete(produto);
                Response.Redirect("Index.aspx");
            }
            else
            {
                if (command.Equals("Edit"))
                {
                    var produtoId = produto.Id;
                    Convert.ToString(produtoId);
                    // Redirecionando para tela de edicao
                    Response.Redirect("Editar.aspx?Id=" + produtoId);
                }
            }
        }

        private void AtualizaGrid()
        {
            var produtos = _contexto.Produto;

            gridProdutos.DataSource = produtos.ToList();
            gridProdutos.DataSource = _controller.ListProdutos();
            gridProdutos.DataBind();
        }
    }
}