using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPWinForm_equipo_30
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> carrito;
            //     carrito   = Session["Carrito"] != null ? (List<Articulo>)Session["Carrito"] : new List<Articulo>();
            if (Session["Carrito"] != null)
            {
                carrito = (List<Articulo>)Session["Carrito"];
            }
            else
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                carrito = new List<Articulo>();
                Session.Add("Carrito", carrito);
            }

            if(Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                List<Articulo> articuloList = (List<Articulo>)Session["ListaArticulos"];
                Articulo seleccion = articuloList.Find(x => x.ID == id);
                carrito.Add(seleccion);
            }
            

            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();

        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = dgvCarrito.SelectedIndex;
            
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];

            carrito.RemoveAt(id);
            Session.Add("Carrito", carrito);

            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();

        }
    }
}