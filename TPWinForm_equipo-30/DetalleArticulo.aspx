<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPWinForm_equipo_30.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle Articulo</h1>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtID" class="form-label">ID: </label>
                <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodArticulo" class="form-label">Codigo Articulo: </label>
                <asp:TextBox ID="txtCodArticullo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombreArticulo" class="form-label">Nombre: </label>
                <asp:TextBox ID="txtNombreArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion: </label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca: </label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria: </label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtImagen" class="form-label">Imagen: </label>
                <asp:TextBox ID="txtImagen" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                    <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-dark" runat="server" Visible="false" Text="Modificar"></asp:Button>
                    <a href="Default.aspx" Class="btn btn-danger">Volver</a>
                    <asp:Button ID="btnCarrito" OnClick="btnCarrito_Click" runat="server" Text="Agregar al Carrito" CssClass="btn btn-secondary" />
            
            </div>
        </div>
    </div>

</asp:Content>
