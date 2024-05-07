<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="TPWinForm_equipo_30.ArticulosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Articulos</h1>

    <asp:GridView ID="dvgArticulos" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">   
            <Columns>
              <asp:BoundField Headertext="Codigo"  Datafield="CodArticulo"/>
              <asp:BoundField HeaderText="Nombre" DataField="NombreArticulo" />
              <asp:BoundField HeaderText="Categoria" DataField="Categoria.NombreCategoria" />
              <asp:BoundField HeaderText="Marca" DataField="Marca.NombreMarca" />
              <asp:BoundField HeaderText="Precio" DataField="Precio" />
            </Columns>
    </asp:GridView>

</asp:Content>
