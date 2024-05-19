using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Windows;

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
                        ActualizarCarrito();
                    }
                    else
                    {
                        seleccion.cantidad++;                   //si se agrega un elemento existente en el carrito, le sumo +1
                        ActualizarCarrito();
                    }
                }

                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();
                CalcularImporteTotal();
                ActualizarCarrito();
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
                ActualizarCarrito();
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
            Button btn = (Button)sender;                                    //guardamos en una variable button el boton que desencadena el evento
            GridViewRow row = (GridViewRow)btn.NamingContainer;             //guardamos la fila del dgv que se encuentra el boton que acciona el evento 
            int rowIndex = row.RowIndex;                                    //agarramos el indice de la fila del dgv para manipular los controles de dicha fila

            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            if (carrito != null && rowIndex >= 0 && rowIndex < carrito.Count)    //validamos que se substraiga un elemento existente dentro del carrito
            {
                Articulo articulo = carrito[rowIndex];
                if (articulo.cantidad > 0)
                {
                    articulo.cantidad--;                                        //substraemos si la cantidad es > a 0
                }

                Session["Carrito"] = carrito;                                   //actualizamos la session con la nueva cantidad
                Label lbl = (Label)row.FindControl("lblCant");
                int cantidad = int.Parse(lbl.Text);
                if (cantidad <= 1)
                {                                                               //buscamos el lbl de cantidad para poder obtener el valor del label
                    carrito.Remove(articulo);                                   //removemos el articulo si es menor a 1
                }

                dgvCarrito.DataSource = carrito;
                dgvCarrito.DataBind();                                          //actualizamos el dgv con los valores nuevos y calculamos imp total
                CalcularImporteTotal();
                ActualizarCarrito();
            }
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;                                
            GridViewRow row = (GridViewRow)btn.NamingContainer;             
            int rowIndex = row.RowIndex;                                 

            List<Articulo> carrito = (List<Articulo>)Session["Carrito"];
            if (carrito != null && rowIndex >= 0 && rowIndex < carrito.Count)   //validamos que se adicione un elemento existente dentro del carrito
            {
                Articulo articulo = carrito[rowIndex];                  //obtenemos el articulo con el indice de la grilla
                articulo.cantidad++;        
                Session["Carrito"] = carrito;                           //sumamos y guardamos en la session
                

                dgvCarrito.DataSource = carrito;                        
                dgvCarrito.DataBind();
                CalcularImporteTotal();                                 //bindeamos al dgv y calculamos importe final
                ActualizarCarrito();
            }
        }
        private void ActualizarCarrito()
        {
            if (Session["Carrito"] != null)
            {
                var articulosSeleccionados = (List<Articulo>)Session["Carrito"];

                int totalItems = 0;

                foreach (var item in articulosSeleccionados)
                {
                    totalItems += item.cantidad;
                }

                string script = $"document.getElementById('cartItemCount').innerText = '{totalItems}';";
                ScriptManager.RegisterStartupScript(this, GetType(), "updateCartCount", script, true);
            }
        }

    }
}
