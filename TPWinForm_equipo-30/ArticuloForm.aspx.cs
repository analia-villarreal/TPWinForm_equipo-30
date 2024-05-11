using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPWinForm_equipo_30
{
    public partial class ArticuloForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio MaNegocio = new MarcaNegocio();
                    List<Marca> listaMarca = MaNegocio.listarMarcas();

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "IDMarca";
                    ddlMarca.DataTextField = "NombreMarca";
                    ddlMarca.DataBind();

                    CategoriaNegocio caNegocio = new CategoriaNegocio();
                    List<Categoria> listaCate = caNegocio.listarCategorias();

                    ddlCategoria.DataSource = listaCate;
                    ddlCategoria.DataValueField = "IDCategoria";
                    ddlCategoria.DataTextField = "NombreCategoria";
                    ddlCategoria.DataBind(); 
                }

            }
            catch (Exception)
            {

                throw;
            }

        }



        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            Articulo art = new Articulo();

            try
            {
                art.ID = int.Parse(Request.QueryString["ID"]);
                art.NombreArticulo = txtNombre.Text;
                art.Descripcion = txtDescripcion.Text;
                art.Marca = new Marca();
                art.Marca.IDMarca = int.Parse(ddlMarca.SelectedValue);
                art.Categoria = new Categoria();
                art.Categoria.IDCategoria = int.Parse(ddlCategoria.SelectedValue);
                art.ImagenUrl = txtUrlimagen.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);

                negocio.modificar(art);
                //Response.Redirect("MensajeModificar.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                //Response.Redirect("", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            int ID = int.Parse(Request.QueryString["ID"]);

            //negocio.eliminar(ID);

            Response.Redirect("ArticulosLista.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                Articulo art = new Articulo();

                art.CodArticulo = txtCodigo.Text;
                art.NombreArticulo = txtNombre.Text;
                art.Descripcion = txtDescripcion.Text;
                art.Marca = new Marca();
                art.Marca.IDMarca = int.Parse(ddlMarca.SelectedValue);
                art.Categoria = new Categoria();
                art.Categoria.IDCategoria = int.Parse(ddlCategoria.SelectedValue);
                art.ImagenUrl = txtUrlimagen.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);


                negocio.agregar(art);
                //Response.Redirect("", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                //Response.Redirect("", false);
            }
        }
    }
    
    
}