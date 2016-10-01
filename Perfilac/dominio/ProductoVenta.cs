using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class ProductoVenta:EntidadPersistente
    {
        private int cant;

        public int Cant
        {
            get { return cant; }
            set { cant = value; }
        }

        private double ancho;

        public double Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }
        private double alto;

        public double Alto
        {
            get { return alto; }
            set { alto = value; }
        }

	

        private Producto prod;

        public Producto Prod
        {
            get { return prod; }
            set { prod = value; }
        }

        private Venta vent;

        public Venta Vent
        {
            get { return vent; }
            set { vent = value; }
        }

        public ProductoVenta():base()
        {
            this.cant = 0;
            this.ancho = 0;
            this.alto = 0;
            this.prod = null;
            this.vent = null;
        }

        public double metrosCuadrado()
        {
            return (this.ancho / 1000) * (this.alto / 1000)*this.cant;
        }


        public double precioCUP()
        {
            return this.prod.PrecioCUP * this.metrosCuadrado() / this.cant;
        }
        public double precioCUC()
        {
            return this.prod.PrecioCUC * this.metrosCuadrado() / this.cant;
        }
        public decimal ImporteCUC()
        {
            
            double imp  =  this.precioCUC() * this.cant;
            decimal numero = decimal.Parse(imp.ToString());
            return Math.Round(numero, 2);
        }
        public decimal ImporteCUP()
        {
            double imp = this.precioCUP() * this.cant;
            decimal numero = decimal.Parse(imp.ToString());
            return Math.Round(numero, 2);
        }


    }
}
