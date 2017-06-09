<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incluir.aspx.cs" Inherits="ProjetoLoja.View.Categoria.Incluir" %>
<asp:Content ID="IncluirCategoriaForm" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <h2>Cadastrar</h2>
        <div class="form-group">
            <label for="Nome" class="col-lg-2 control-label">Nome da Categoria:</label>
            <div class="col-lg-10">
                <asp:TextBox MaxLength="100" runat="server" class="form-control" ID="txtNome"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="form-group">
            <label for="Descricao" class="col-lg-2 control-label">Descrição:</label>
            <div class="col-lg-10">
                <asp:TextBox MaxLength="500" class="form-control" TextMode="MultiLine" runat="server" ID="txtDescricao"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="form-group">
            <label for="textArea" class="col-lg-2 control-label">Status: </label>
            <div class="col-lg-10">
                <asp:CheckBox ID="chkAtivo" runat="server" Text="Ativo" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <a href="Index.aspx" class="btn btn-primary">Voltar</a>
                <asp:Button runat="server" type="submit" class="btn btn-primary" Style="width: 100px" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </div>
        </div>
    </fieldset>
</asp:Content>
