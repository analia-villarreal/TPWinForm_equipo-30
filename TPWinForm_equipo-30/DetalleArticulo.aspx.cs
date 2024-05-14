using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace TPWinForm_equipo_30
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.ListaconSP();

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

            if (Request.QueryString["id"] != null)
            {
                int ID = int.Parse(Request.QueryString["id"]);
                Articulo seleccion = ListaArticulos.Find(x => x.ID == ID);
                txtID.ReadOnly = true;
                txtCodArticullo.ReadOnly = true;

                txtID.Text = seleccion.ID.ToString();
                txtNombreArticulo.Text = seleccion.NombreArticulo;
                txtCodArticullo.Text = seleccion.CodArticulo;
                txtDescripcion.Text = seleccion.Descripcion;
                //ddlCategoria.SelectedItem.Text = seleccion.Categoria.NombreCategoria.ToString();      
                //ddlMarca.SelectedItem.Text = seleccion.Marca.NombreMarca.ToString();
                txtImagen.Text = seleccion.ImagenUrl;
                txtPrecio.Text = seleccion.Precio.ToString();

            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}