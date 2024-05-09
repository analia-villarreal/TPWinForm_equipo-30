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
    public partial class ArticulosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dvgArticulos.DataSource = negocio.ListaconSP();
            dvgArticulos.DataBind();
        }

        protected void dvgArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvgArticulos.PageIndex = e.NewPageIndex;
            dvgArticulos.DataBind();
        }

        protected void dvgArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dvgArticulos.SelectedDataKey.Value.ToString();

            Response.Redirect("ArticuloForm.aspx?ID=" + id);
        }
    }
}