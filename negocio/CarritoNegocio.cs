using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CarritoNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            lista.Add(new Articulo(1, "Telefono"));
            lista.Add(new Articulo(2, "Televisor"));
            lista.Add(new Articulo(3, "Aspiradora"));
            lista.Add(new Articulo(4, "Lavarropas"));

            return lista;
        }
    }
}
