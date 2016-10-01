using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class EntidadPersistente
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public EntidadPersistente()
        {
            this.id = -1;
        }
    }
}
