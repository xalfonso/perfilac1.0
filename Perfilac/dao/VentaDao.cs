using System;
using System.Collections.Generic;
using System.Text;
using Perfilac.origen_datos;
using System.Data.Common;
using System.Data.Odbc;
using Perfilac.dominio;
using System.Globalization;

namespace Perfilac.dao
{
    public  class VentaDao : DaoGenerico
    {
        public VentaDao():base()
        {

        }


        private List<ProductoVenta> listProductoVenta(int idventa)
        {
            //Este metodo depende de que se haya abierto una conexion en consultarVentas
            OdbcCommand command = this.Conect.CreateCommand();           
            command.CommandText = "SELECT TProductoVenta.*,TProducto.precioCUC,TProducto.precioCUP FROM TProducto INNER JOIN TProductoVenta ON TProducto.Id = TProductoVenta.producto WHERE (((TProductoVenta.venta)="+idventa+"))";
            List<ProductoVenta> listProductoVenta = new List<ProductoVenta>();


            try
            {

                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);


                while (reader.Read())
                {

                    Producto product = new Producto();
                    product.PrecioCUC = double.Parse(reader["precioCUC"].ToString());
                    product.PrecioCUP = double.Parse(reader["precioCUP"].ToString());
                    ProductoVenta productVenta = new ProductoVenta();
                    productVenta.Alto = double.Parse(reader["alto"].ToString());
                    productVenta.Ancho = double.Parse(reader["ancho"].ToString());
                    productVenta.Cant = (int)reader["cantidad"];
                    productVenta.Prod = product;
                    listProductoVenta.Add(productVenta);
                }
                reader.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return listProductoVenta;
        }

        public List<Venta> consultarVentas(int tipo,DateTime fechaInicio,DateTime fechaFin)
        {
            this.Conect = daoConection.getConexion();
            this.Conect.Open();
            OdbcCommand command = this.Conect.CreateCommand();
            String formato = "\"dd/mm/aaaa\"";
            command.CommandText = "SELECT TVenta.*, TCliente.nombre AS client, TPersonaCliente.primerNombre, TPersonaCliente.segundoNombre, TPersonaCliente.primerApellido, TPersonaCliente.segundoApellido FROM (TVenta INNER JOIN TCliente ON TVenta.cliente = TCliente.id) INNER JOIN TPersonaCliente ON (TPersonaCliente.Id = TVenta.comercial) AND (TCliente.Id = TPersonaCliente.cliente)  where (((TVenta.tipo)=0) AND ((TVenta.fecha) Between # " + fechaInicio.Month + "/" + fechaInicio.Day + "/" + fechaInicio.Year + "# And # " + fechaFin.Month + "/" + fechaFin.Day + "/" + fechaFin.Year + " #))";
          
            

            List<Venta> listVenta = new List<Venta>();


            try
            {
                
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);


                while (reader.Read())
                {
                    Cliente cliente = new Cliente("",(String)reader["client"],"","",null,"","");
                    PersonaCliente personaCliente = new PersonaCliente((String)reader["primerNombre"], (String)reader["segundoNombre"], (String)reader["primerApellido"], (String)reader["segundoApellido"], "", "", "");
                    TipoVenta tVenta = new TipoVenta();
                    if (tipo == 1)
                        tVenta = TipoVenta.factura;
                    Venta venta = new Venta(cliente, personaCliente, (DateTime)reader["fecha"], null, tVenta);
                    venta.Id = (int)reader["id"];
                    //TipoProducto tProducto = new TipoProducto((String)reader["tipoProducto"]);
                    //Producto nuevo = new Producto((String)reader["codigo"], (String)reader["descripcion"], int.Parse(reader["noFicha"].ToString()), double.Parse(reader["precioCUC"].ToString()), double.Parse(reader["precioCUP"].ToString()), (String)reader["suministrador"], (String)reader["color"], tEnchape, tProducto);
                    //nuevo.Id = int.Parse(reader["id"].ToString());
                    venta.ListProductoVenta = listProductoVenta(venta.Id);
                    listVenta.Add(venta);
                }
                reader.Close();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(command.CommandText);
                Console.WriteLine(ex.Message);
               
            }
            this.Conect.Close();
           

            return listVenta;
        }
        public int salvarVentaCompleta(Venta venta)
        {
            this.Conect = daoConection.getConexion();
            this.Conect.Open();
            OdbcCommand command = this.Conect.CreateCommand();
            this.Transaction = this.Conect.BeginTransaction();
            salvarVenta(venta);
            int idVenta = 0;

            command.CommandText = "Select max(id) from TVenta";
            command.Transaction = this.Transaction;

            try
            {
                idVenta = int.Parse(command.ExecuteScalar().ToString());
                Console.WriteLine(command.CommandText);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }

            foreach (ProductoVenta var in venta.ListProductoVenta)
            {
                var.Vent.Id = idVenta;
                salvarVentasProductos(var);
            }

            foreach (Ingreso var in venta.ImportePagado)
            {
                var.Venta.Id = idVenta;
                salvarVentasPagos(var);
            }

            this.Transaction.Commit();
            this.Conect.Close();

            return idVenta;
        }

        private void salvarVentasPagos(Ingreso ingreso)
        {
            //Este metodo depende de que se haya abierto una conexion en salvarVentaCompleta
            OdbcCommand command = this.Conect.CreateCommand();
            command.CommandText = "insert into TIngreso(venta,ingreso,cheque,moneda,cliente) values('" + ingreso.Venta.Id + "','" + ingreso.Importe + "','" + ingreso.Cheque + "','" + ingreso.Moneda.ToString() + "','" + ingreso.Client.Id + "')";
            command.Transaction = this.Transaction;

            try
            {
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
        }

        private void salvarVentasProductos(ProductoVenta productoVenta)
        {
            OdbcCommand command = this.Conect.CreateCommand();
            command.CommandText = "insert into TProductoVenta(cantidad,venta,producto,ancho,alto) values('" + productoVenta.Cant + "','" + productoVenta.Vent.Id + "','" + productoVenta.Prod.Id + "','" + productoVenta.Ancho + "','" + productoVenta.Alto + "')";
            command.Transaction = this.Transaction;

            try
            {
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
        }

        public void salvarVenta(Venta venta)
        {
            
            OdbcCommand command = this.Conect.CreateCommand();
            command.CommandText = "insert into TVenta(cliente,comercial,fecha,tipo) values('" + venta.Cliente.Id + "','" + venta.Comercial.Id + "','" + venta.Fecha + "','" + (int)venta.TipoVenta + "')";
                      
            command.Transaction = this.Transaction;
            
            try
            {
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                
                reader.Close();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
        }
    }
}
