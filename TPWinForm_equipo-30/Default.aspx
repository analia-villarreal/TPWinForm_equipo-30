<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWinForm_equipo_30.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>LISTA</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <% foreach (dominio.Articulo item in ListaArticulos)
            {%>
        
        <div class="col">
            <div class="card" style="width: 200px; height: 450px;">
                <img src="<%: item.ImagenUrl %>" class="card-img-top" alt="">
                <div class="card-body">
                    <h5 class="card-title"><%: item.NombreArticulo %></h5>
                    <p class="card-text"><%: item.Descripcion %></p>
                    <a href="DetalleArticulo.aspx?id=<%: item.ID %>" type="button" class="btn btn-info">Ver detalle</a>
                </div>
                <a href="Carrito.aspx?id=<%: item.ID %>" class="btn btn-secondary">Agregar al Carrito</a>
            </div>
        </div>

        <%}
        %>
    </div>

</asp:Content>
