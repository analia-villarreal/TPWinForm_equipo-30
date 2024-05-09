<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="TPWinForm_equipo_30.ArticulosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Articulos</h1>

    <asp:GridView ID="dvgArticulos" runat="server" OnPageIndexChanging="dvgArticulos_PageIndexChanging" OnSelectedIndexChanged="dvgArticulos_SelectedIndexChanged" DataKeyNames="ID" CssClass="table table-dark" AutoGenerateColumns="false" AllowPaging="true" PageSize="15">   
            <Columns>
              <asp:BoundField Headertext="Codigo"  Datafield="CodArticulo"/>
              <asp:BoundField HeaderText="Nombre" DataField="NombreArticulo" />
              <asp:BoundField HeaderText="Categoria" DataField="Categoria.NombreCategoria" />
              <asp:BoundField HeaderText="Marca" DataField="Marca.NombreMarca" />
              <asp:BoundField HeaderText="Precio" DataField="Precio" />
              <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
            </Columns>
    </asp:GridView>
     <a href="ArticuloForm.aspx">Agregar</a>
</asp:Content>
