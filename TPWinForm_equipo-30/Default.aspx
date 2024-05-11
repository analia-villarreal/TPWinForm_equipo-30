<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWinForm_equipo_30.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>LISTA</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <% foreach (dominio.Articulo item in ListaArticulos)
            {%>

        <div class="col">
            <div class="card">
                <img src="<%: item.ImagenUrl %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: item.NombreArticulo %></h5>
                    <p class="card-text"><%: item.Descripcion %></p>
                    <a href="DetalleArticulo.aspx?id=<%: item.ID %>" type="button" class="btn btn-info">Ver detalle</a>
                    <asp:ImageButton ID="btnCarrito" Width="35" OnClick="btnCarrito_Click" Height="35" src="https://cdn.icon-icons.com/icons2/933/PNG/512/shopping-cart_icon-icons.com_72552.png" runat="server" />
                </div>
            </div>
        </div>

        <%}
        %>
    </div>

</asp:Content>
