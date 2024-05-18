<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWinForm_equipo_30.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>Carrito</h1>
    <h2>Artículos en el Carrito:</h2>
    <div class="row">
        <div class="col-6">
            <asp:GridView CssClass="table" runat="server" ID="dgvCarrito" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged" EnableEventValidation="false" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="NombreArticulo" DataField="NombreArticulo" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>


                            <asp:Button ID="btnMenos" runat="server" Text="-" OnClick="btnMenos_Click" />
                            <asp:Label ID="lblCant" runat="server" Text='<%# Bind("cantidad") %>' />
                            <asp:Button ID="btnMas" runat="server" Text="+" OnClick="btnMas_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Eliminar" SelectText="Eliminar" ShowSelectButton="true" />
                </Columns>

            </asp:GridView>
        </div>
    </div>

    <a href="Default.aspx" class="btn btn-danger">Volver</a>
    <hr />
    <%--    <div class="col-2 border border-primary rounded-pill p-3 mb-2 bg-secondary text-white">
    </div>
    <asp:Button ID="btnCalcularImporte" runat="server" Text="Calcular Importe Total" CssClass="btn btn-outline-info" OnClick="btnCalcularImporte_Click" />
    <asp:Label ID="lblImporteTotal" runat="server" Text="Importe Total: " />
    --%>

    <%if (Session["Carrito"] != null)
        { %>
    <div class="badge badge-danger">
        <span>
            <asp:Label Text="Total" ID="lblImporteTotal1" runat="server" />
        </span>
        <span>
            <asp:Label Text="" ID="lblImporteTotal" runat="server" />
        </span>

    </div>
    <%} %>
</asp:Content>
