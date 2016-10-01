using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class TipoEnchape:EntidadPersistente
    {
        


        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public TipoEnchape(String nombre)
        {
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return nombre;
        }
        public TipoEnchape()
        {
            this.nombre = "";
        }
    }
}
