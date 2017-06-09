<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjetoLoja._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <fieldset>
        <h2>Projeto Loja</h2>
        <div class="form-group">
            <br />
            <div class="col-lg-10 col-lg-offset-2" style="margin-left:-15px">
                <a href="View/Categoria/Index" class="btn btn-primary">Produto</a>
                <a href="View/Produto/Index" class="btn btn-primary">Categoria</a>
        </div>
    </fieldset>
</asp:Content>
