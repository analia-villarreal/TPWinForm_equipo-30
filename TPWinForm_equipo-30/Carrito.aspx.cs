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

            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                List<Articulo> articuloList = (List<Articulo>)Session["ListaArticulos"];
                Articulo seleccion = articuloList.Find(x => x.ID == id);
                if (!IsPostBack)
                {
                    carrito.Add(seleccion);
                }
            }



            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();


        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            Articulo seleccion = new Articulo();
            List<Articulo> articuloList = (List<Articulo>)Session["ListaArticulos"];
            int id = dgvCarrito.SelectedIndex;
            seleccion = carrito[id];
            //seleccion = articuloList.Find(x => x.ID == id);

            //carrito = (List<Articulo>)Session["Carrito"];
            carrito.Remove(seleccion);

            Session.Add("Carrito", carrito);

            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();

        }

        protected void CalcularImporteTotal()
        {
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            if (carrito == null)
            {
                return;
            }
            decimal importeTotal = 0;

            foreach (Articulo articulo in carrito)
            {
                importeTotal += articulo.Precio;
            }
            lblImporteTotal.Text = $"Importe Total: {importeTotal:C}";
        }

        protected void btnCalcularImporte_Click(object sender, EventArgs e)
        {
            CalcularImporteTotal();
        }

    }
}