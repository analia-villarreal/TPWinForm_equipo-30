﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPWinForm_equipo_30
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoNegocio negocio = new CarritoNegocio();
            dgvCarrito.DataSource = negocio.listar();
            dgvCarrito.DataBind();
        }
    }
}