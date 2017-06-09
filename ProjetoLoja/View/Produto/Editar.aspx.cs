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
    public partial class Editar : Page
    {
        private readonly DBLojaEntities _contexto = new DBLojaEntities();
        private readonly ProdutoController _controller = new ProdutoController();
        private readonly CategoriaController _controllerCategoria = new CategoriaController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var IdProduto = Request.QueryString["Id"];
                var Id = Convert.ToInt32(IdProduto);

                var objProduto = _controller.GetById(Id);
                if (objProduto != null)
                {
                    txtNome.Text = objProduto.Nome;

                    if (!String.IsNullOrEmpty(objProduto.Descricao))
                        txtDescricao.Text = objProduto.Descricao;
                    else
                        txtDescricao.Text = string.Empty;

                    if (objProduto.Ativo == 1)
                        chkAtivo.Checked = true;
                    else
                        chkAtivo.Checked = false;

                    #region Combobox categorias

                    var categorias = _controllerCategoria.GetAllCategorias();

                    listCategorias.DataSource = categorias.ToList();
                    listCategorias.DataTextField = "Nome";
                    listCategorias.DataValueField = "Id";
                    listCategorias.DataBind();

                    listCategorias.SelectedValue = Convert.ToString(objProduto.idCategoria);

                    #endregion
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var IdProduto = Request.QueryString["Id"];
                var Id = Convert.ToInt32(IdProduto);

                var model = _controller.GetById(Id);
                if (model != null)
                {
                    if (String.IsNullOrEmpty(txtNome.Text))
                    {
                        var validaNome = "O campo 'Nome' não pode estar em branco, favor verificar!";
                        ClientScript.RegisterStartupScript(this.GetType(), "script", "alert('" + validaNome + "');", false);

                        return;
                    }

                    model.Nome = txtNome.Text;

                    if (!String.IsNullOrEmpty(txtDescricao.Text))
                        model.Descricao = txtDescricao.Text;
                    else
                        model.Descricao = string.Empty;

                    if (chkAtivo.Checked)
                        model.Ativo = 1;
                    else
                        model.Ativo = 0;

                    model.idCategoria = Convert.ToInt32(listCategorias.SelectedValue);

                    _controller.Editar(model);
                }
            }
            catch
            {
                throw;
            }

            Response.Redirect("Index.aspx");
        }
    }
}