using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

namespace TPWinForm_equipo_30
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar(object sender, EventArgs e)
        {
            string detalle = lblSearch.Text;
            Response.Redirect("DetalleArticulo.aspx?detalle=" + detalle);
        }
    }
}