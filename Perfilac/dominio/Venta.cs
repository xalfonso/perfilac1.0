using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class Venta:EntidadPersistente
    {
        private List<ProductoVenta> listProductoVenta;

        public List<ProductoVenta> ListProductoVenta
        {
            get { return listProductoVenta; }
            set { listProductoVenta = value; }
        }


        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private PersonaCliente comercial;

        public PersonaCliente Comercial
        {
            get { return comercial; }
            set { comercial = value; }
        }


        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        
        private List<Ingreso> importePagado;

        public List<Ingreso> ImportePagado
        {
            get { return importePagado; }
            set { importePagado = value; }
        }

        private TipoVenta tipoVenta;

        public TipoVenta TipoVenta
        {
            get { return tipoVenta; }
            set { tipoVenta = value; }
        }

        public decimal ImporteCUCTotal()
        {
            decimal importeTotal = 0;
            foreach (ProductoVenta var in this.listProductoVenta)
            {
                importeTotal += var.ImporteCUC();
            }
            return importeTotal;
        }

        public decimal ImporteCUPTotal()
        {
            decimal importeTotal = 0;
            foreach (ProductoVenta var in this.listProductoVenta)
            {
                importeTotal += var.ImporteCUP();
            }
            return importeTotal;
        
        }
        public Venta(Cliente cliente, PersonaCliente comercial, DateTime fecha,List<ProductoVenta> listProductoVenta,TipoVenta tipoVenta)
            : base()
        {
            this.cliente = cliente;
            this.comercial = comercial;
            this.fecha = fecha;
            this.listProductoVenta = listProductoVenta;
            this.tipoVenta = tipoVenta;
        }
        


    }
}
