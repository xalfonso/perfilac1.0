using System;
using System.Collections.Generic;
using System.Text;

namespace Perfilac.dominio
{
    public class EmpresaPerfilac
    {
        private List<Producto> productos;

        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }

        private List<Cliente> listCliente;

        public List<Cliente> ListCliente
        {
            get { return listCliente; }
            set { listCliente = value; }
        }

        private List<Venta> listVenta;

        public List<Venta> ListaVenta
        {
            get { return listVenta; }
            set { listVenta = value; }
        }

        private String numeroCuentaAcreedorMN;

        public String NumeroCuentaAcreedorMN
        {
            get { return numeroCuentaAcreedorMN; }
            set { numeroCuentaAcreedorMN = value; }
        }
        private String numeroCuentaAcreedorCUC;

        public String NumeroCuentaAcreedorCUC
        {
            get { return numeroCuentaAcreedorCUC; }
            set { numeroCuentaAcreedorCUC = value; }
        }

        public EmpresaPerfilac()
        {
            this.productos = new List<Producto>();
            this.listCliente = new List<Cliente>();
        }

        
    }
}
