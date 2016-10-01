using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class Producto:EntidadPersistente
    {
        private String codigo;

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private String descripcion;

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int noFicha;

        public int NoFicha
        {
            get { return noFicha; }
            set { noFicha = value; }
        }

        private double precioCUP;

        public double PrecioCUP
        {
            get { return precioCUP; }
            set { precioCUP = value; }
        }

        private double precioCUC;

        public double PrecioCUC
        {
            get { return precioCUC; }
            set { precioCUC = value; }
        }

        private String suministrador;

        public String Suministrador
        {
            get { return suministrador; }
            set { suministrador = value; }
        }

        private String color;

        public String Color
        {
            get { return color; }
            set { color = value; }
        }

        private TipoProducto tipo;

        public TipoProducto Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private TipoEnchape enchape;

        public TipoEnchape Enchape
        {
            get { return enchape; }
            set { enchape = value; }
        }

        public Producto(String codigo,String descripcion,int noFicha,double precioCUC,double precioCUP,String suministrador,String color,TipoEnchape enchape,TipoProducto tipo):base()
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.noFicha = noFicha;
            this.precioCUC = precioCUC;
            this.precioCUP = precioCUP;
            this.suministrador = suministrador;
            this.color = color;
            this.tipo = tipo;
            this.enchape = enchape;

        }
        public Producto()
            : base()
        {
            this.codigo = "";
            this.descripcion = "";
            this.noFicha = -1;
            this.precioCUC = 0;
            this.precioCUP = 0;
            this.suministrador = "";
            this.color = "";
            this.tipo = new TipoProducto();
            this.enchape = new TipoEnchape();

        }
    }
}
