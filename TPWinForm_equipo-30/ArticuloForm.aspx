<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ArticuloForm.aspx.cs" Inherits="TPWinForm_equipo_30.ArticuloForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- %>
        public decimal Precio { get; set;} --%>

    <div class="row">
        <div class="col-6">

            <div class="row g-3 align-items-center">   
                <div class="col-auto">
                    <label class="col-form-label">ID</label>
                </div>
                <div class="col-auto">
                    <asp:TextBox runat="server" ID="txtID" /> 
                </div>
            </div>
            <div class="row g-3 align-items-center">   
                <div class="col-auto">
                    <label class="col-form-label">Codigo</label>
                </div>
                <div class="col-auto">
                    <asp:TextBox runat="server" ID="txtCodigo" />                      
                </div>
            </div>
            <div class="row g-3 align-items-center">   
                <div class="col-auto">
                    <label class="col-form-label">Nombre</label>
                </div>
                <div class="col-auto">
                    <asp:TextBox runat="server" ID="txtNombre" />                      
                </div>
            </div>
            <div class="row g-3 align-items-center">   
                <div class="col-auto">
                    <label class="col-form-label">Descripcion</label>
                </div>
                <div class="col-auto">
                    <asp:TextBox runat="server" ID="txtDescripcion" />                      
                </div>
            </div>
            <div class="row g-3 align-items-center">   
                <div class="col-auto">
                    <label class="col-form-label">Marca</label>
                </div>
                <div class="col-auto">
                    <asp:DropDownList ID="ddlMarca" runat="server" />                      
                </div>
            </div>
            <div class="row g-3 align-items-center">   
                <div class="col-auto">
                    <label class="col-form-label">Categoria</label>
                </div>
                <div class="col-auto">
                    <asp:DropDownList ID="ddlCategoria" runat="server" />                      
                </div>
            </div>
            <div class="row g-3 align-items-center">   
                <div class="col-auto">
                    <label class="col-form-label">Imagen</label>
                </div>
                <div class="col-auto">
                    <asp:TextBox runat="server" ID="txtUrlimagen" />                      
                </div>
            </div>
            <div class="row g-3 align-items-center">   
                <div class="col-auto">
                    <label class="col-form-label">Precio</label>
                </div>
                <div class="col-auto">
                    <asp:TextBox runat="server" ID="txtPrecio" />                      
                </div>
            </div>

            <div class="mb-3 row">
               <%if (Request.QueryString["ID"] != null)
              {%>
                  <div class="col-sm-10">
                    <asp:Button CssClass="btn btn-primary" ID="btnModificar" OnClick="btnModificar_Click" runat ="server" Text="Modificar" />
                  </div>
                  <div class="col-sm-10">
                    <asp:Button CssClass="btn btn-primary" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" Text="Eliminar" />
                  </div>
                
               <%}
                 else
                 {%>
                  <div class="col-sm-10">
                    <asp:Button CssClass="btn btn-primary" ID="btnAceptar"  OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
                  </div>
               <%}%>
             </div>

       </div>
    </div>

</asp:Content>
