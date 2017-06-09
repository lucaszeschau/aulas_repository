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
    public partial class Editar : Page
    {
        private readonly DBLojaEntities _contexto = new DBLojaEntities();
        private readonly CategoriaController _controller = new CategoriaController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var IdCategoria = Request.QueryString["Id"];
                var Id = Convert.ToInt32(IdCategoria);

                var objCategoria = _controller.GetById(Id);
                if (objCategoria != null)
                {
                    txtNome.Text = objCategoria.Nome;

                    if (!String.IsNullOrEmpty(objCategoria.Descricao))
                        txtDescricao.Text = objCategoria.Descricao;
                    else
                        txtDescricao.Text = string.Empty;

                    if (objCategoria.Ativo == 1)
                        chkAtivo.Checked = true;
                    else
                        chkAtivo.Checked = false;
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
                var IdCategoria = Request.QueryString["Id"];
                var Id = Convert.ToInt32(IdCategoria);

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