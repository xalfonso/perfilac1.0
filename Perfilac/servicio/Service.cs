using System;
using System.Collections.Generic;
using System.Text;
using Perfilac.dominio;
using Perfilac.dao;

namespace Perfilac.servicio
{
    public class Service
    {
        private EmpresaPerfilac emp;

        public EmpresaPerfilac Emp
        {
            get { return emp; }
            set { emp = value; }
        }

        private ProductoDao daoProducto;

        public ProductoDao DaoProducto
        {
            get { return daoProducto; }
            set { daoProducto = value; }
        }

        private UsuarioDao daoUsuario;

        public UsuarioDao DaoUsuario
        {
            get { return daoUsuario; }
            set { daoUsuario = value; }
        }


        private NomencladorDao daoNomenclador;

        public NomencladorDao DaoNomenclador
        {
            get { return daoNomenclador; }
            set { daoNomenclador = value; }
        }

        private ClienteDao daoCliente;

        public ClienteDao DaoCliente
        {
            get { return daoCliente; }
            set { daoCliente = value; }
        }

        private VentaDao daoVenta;

        public VentaDao DaoVenta
        {
            get { return daoVenta; }
            set { daoVenta = value; }
        }


        public void salvarProducto(Producto producto)
        {
            this.DaoProducto.salvarProducto(producto);
        }

        public List<TipoEnchape> obtenerTiposEnchape()
        {
            return this.daoNomenclador.obtenerTiposEnchapes();

        }
        public List<TipoProducto> obtenerTiposProducto()
        {
          return  this.daoNomenclador.obtenerTiposProductos();

        }

        public List<Producto> consultarProductosPorParametros(String codigo, int noFicha, TipoProducto tipo, TipoEnchape enchape)
        {
           return this.DaoProducto.consultarPorParametros(codigo, noFicha, tipo, enchape);
        }
        public List<Producto> consultarProducto()
        {
            return this.emp.Productos;
        }

        public void salvarCliente(Cliente cliente)
        {
            this.DaoCliente.salvarClienteCompleto(cliente);
        }
        public int salvarVenta(Venta venta)
        {
          return DaoVenta.salvarVentaCompleta(venta);
        }
        public List<Cliente> obtenerClientes()
        {
          List<Cliente> result =  this.daoCliente.obtenerTodosClientes();
          foreach (Cliente var in result)
          {
              var.Comerciales = obtenerPersonasClientes(var);
          }
          return result;
        }
        public List<PersonaCliente> obtenerPersonasClientes(Cliente cliente)
        {
            return this.daoCliente.obtenerPersonasClientes(cliente);
        }

        public List<Venta> consultarVentas(int tipo, DateTime fechaInicio, DateTime fechaFin)
        {
            return daoVenta.consultarVentas(tipo, fechaInicio, fechaFin);
        }
        public void salvarUsuario(Usuario user)
        {
            this.daoUsuario.salvarUsuario(user);
        }
        public void eliminarUsuario(int idUsuario)
        {
            this.DaoUsuario.eliminarUsuario(idUsuario);
        }
        public void modificarUsuario(Usuario usuario)
        {
            this.daoUsuario.modificarUsuario(usuario);
        }
        public List<Usuario> listarUsuarios()
        {
            return this.daoUsuario.listarUsuarios();
        }
        public Service()
        {
            this.emp = new EmpresaPerfilac();
            this.daoProducto = new ProductoDao();
            this.daoNomenclador = new NomencladorDao();
            this.daoCliente = new ClienteDao();
            this.daoVenta = new VentaDao();
            this.daoUsuario = new UsuarioDao();

        }
    }
}
