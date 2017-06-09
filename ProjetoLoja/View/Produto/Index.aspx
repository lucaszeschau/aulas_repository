<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjetoLoja.View.Produto.Index" %>
<asp:Content ID="ProdutoForm" ContentPlaceHolderID="MainContent" runat="server">
        <fieldset>
        <h2>Produtos</h2>
        <div class="form-group">
            <asp:GridView ID="gridProdutos" runat="server" OnRowCommand="gridProdutos_RowCommand">
                <Columns>
                    <asp:ButtonField CommandName="Delete" Text=" Excluir " />
                    <asp:ButtonField CommandName="Edit" Text=" Editar " />
                </Columns>
            </asp:GridView>
            <br />
            <div class="col-lg-10 col-lg-offset-2" style="margin-left:-15px">
                <a href="Incluir.aspx" class="btn btn-primary">Cadastrar</a>
            </div>
        </div>
    </fieldset>
</asp:Content>
