using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class TipoProducto:EntidadPersistente
    {
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public TipoProducto(String nombre)
        {
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return nombre;
        }
        public TipoProducto()
        {
            this.nombre = "";
        }
    }
}
