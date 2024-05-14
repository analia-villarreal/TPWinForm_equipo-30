<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWinForm_equipo_30.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>Carrito</h1>
    <h2>Artículos en el Carrito:</h2>
    <div class="row">
        <div class="col-6">
            <asp:GridView CssClass="table" runat="server" ID="dgvCarrito" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="NombreArticulo" DataField="NombreArticulo" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Eliminar" SelectText="Eliminar" ShowSelectButton="true"  />
                </Columns>

            </asp:GridView>
        </div>
    </div>

    <a href="Default.aspx" class="btn btn-danger">Volver</a>
</asp:Content>
