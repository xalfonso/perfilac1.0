using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class Ingreso:EntidadPersistente
    {
        private Venta vent;

        public Venta Venta
        {
            get { return vent; }
            set { vent = value; }
        }


        private Cliente client;

        public Cliente Client
        {
            get { return client; }
            set { client = value; }
        }

	
        
        
        private double importe;

        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        private String cheque;

        public String Cheque
        {
            get { return cheque; }
            set { cheque = value; }
        }

        private TipoMoneda moneda;

        public TipoMoneda Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public Ingreso(double importe,String cheque,TipoMoneda moneda):base()
        {
            this.cheque = cheque;
            this.importe = importe;
            this.moneda = moneda;
        }
        public override string ToString()
        {
            return this.cheque + "  "+this.importe+"$  "+""+moneda.ToString();
        }





    }
}
