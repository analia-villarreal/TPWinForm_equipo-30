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
            if (!IsPostBack)
            {
                List<Articulo> carrito;
                if (Session["Carrito"] != null)
                {
                    carrito = (List<Articulo>)Session["Carrito"];
                }
                else
                {
                    carrito = new List<Articulo>();
                    Session["Carrito"] = carrito;
                }

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    List<Articulo> articuloList = (List<Articulo>)Session["ListaArticulos"];
                    Articulo seleccion = articuloList?.Find(x => x.ID == id);
                    if (seleccion != null && !carrito.Any(x => x.ID == id))
                    {
                        seleccion.cantidad = 1;
                        carrito.Add(seleccion);
                    }
                }

                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();
                CalcularImporteTotal();
            }
        }

        protected void dgvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            int id = dgvCarrito.SelectedIndex;
            if (id >= 0 && id < carrito.Count)
            {
                carrito.RemoveAt(id);
                Session["Carrito"] = carrito;

                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();
                CalcularImporteTotal();
            }
        }

        protected void CalcularImporteTotal()
        {
            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            if (carrito == null) return;

            decimal importeTotal = carrito.Sum(articulo => articulo.Precio * articulo.cantidad);
            lblImporteTotal.Text = $": {importeTotal:C}";
        }

        protected void btnCalcularImporte_Click(object sender, EventArgs e)
        {
            CalcularImporteTotal();
        }

        protected void btnMenos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            if (carrito != null && rowIndex >= 0 && rowIndex < carrito.Count)
            {
                Articulo articulo = carrito[rowIndex];
                if (articulo.cantidad > 0)
                {
                    articulo.cantidad--;
                }
                Session["Carrito"] = carrito;
                Label lbl = (Label)row.FindControl("lblCant");
                int cantidad = int.Parse(lbl.Text);
                if (cantidad < 2)
                {
                    carrito.Remove(articulo);
                }

                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();
                CalcularImporteTotal();
            }
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            if (carrito != null && rowIndex >= 0 && rowIndex < carrito.Count)
            {
                Articulo articulo = carrito[rowIndex];
                articulo.cantidad++;
                Session["Carrito"] = carrito;
                

                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();
                CalcularImporteTotal();
            }
        }
    }
}
