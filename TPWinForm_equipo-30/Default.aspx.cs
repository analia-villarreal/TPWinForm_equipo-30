using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Net;

namespace TPWinForm_equipo_30
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargaCarrito();
            }

            if (Session["ListaArticulos"] != null)
                ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
            else
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.ListaconSP();
                Session.Add("ListaArticulos", ListaArticulos);
            }

        }

        protected void btnCarrito_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Carrito.aspx");

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

        private void cargaCarrito()
        {
            var negocio = new ArticuloNegocio();
            try
            {
                ListaArticulos = negocio.ListaconSP();

                foreach (var item in ListaArticulos)
                {
                    if (!CargarImagen(item.ImagenUrl))
                    {
                        item.ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTjiwyJrkkP9wKr3KSzBMIEbvtRHhHeTyFWyZpNuRLgcw&s";
                    }
                }

                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }
        }

        private bool CargarImagen(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return (response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch
            {
                return false;
            }
        }

    }
}