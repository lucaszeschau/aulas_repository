using ProjetoLoja.Controller;
using ProjetoLoja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoLoja.View.Categoria
{
    public partial class Index : Page
    {
        private readonly DBLojaEntities _contexto = new DBLojaEntities();
        private readonly CategoriaController _controller = new CategoriaController();

        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaGrid();

            #region Gerando alerta JS

            // sem updatepanel
            if (gridCategorias.Rows.Count > 0)
            {
                var mensagem = "Lista carregada com sucesso";
                ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + mensagem + "');", true);
            }

            // com update panel
            //var ID2 = "Whatever the data is";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ID2 + "');", true);

            #endregion
        }

        protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Detectando a linha que foi clicada
            int linha = Convert.ToInt32(e.CommandArgument);

            // Recuperando o id do Objeto (lembrando que 2, do Cells[2], é a coluna onde esta o id)
            int idObjeto = Convert.ToInt32(gridCategorias.Rows[linha].Cells[2].Text);
            var categoria = _controller.GetById(idObjeto);

            // Nome do comando para saber a acao
            string command = e.CommandName;

            // Proximos passos

            // adicionar id na Session

            if (command.Equals("Delete"))
            {
                _controller.Delete(categoria);
                Response.Redirect("Index.aspx");
                // Redirecionando para tela de exclusao
                //Response.Redirect("Excluir.aspx");
            }
            else
            {
                if (command.Equals("Edit"))
                {
                    var categoriaId = categoria.Id;
                    Convert.ToString(categoriaId);
                    // Redirecionando para tela de edicao
                    Response.Redirect("Editar.aspx?Id=" + categoriaId);
                }
            }
        }

        private void AtualizaGrid()
        {
            var categorias = _contexto.Categoria;

            gridCategorias.DataSource = categorias.ToList();
            gridCategorias.DataSource = _controller.ListCategorias();
            gridCategorias.DataBind();
        }
    }
}