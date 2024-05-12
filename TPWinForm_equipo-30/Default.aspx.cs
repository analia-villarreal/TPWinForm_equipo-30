using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPWinForm_equipo_30
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.ListaconSP();

        }

        protected void btnCarrito_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Carrito.aspx");

        }
    }
}