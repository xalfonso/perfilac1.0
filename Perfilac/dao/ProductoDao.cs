using System;
using System.Collections.Generic;
using System.Text;
using Perfilac.origen_datos;
using System.Data.Common;
using System.Data.Odbc;
using Perfilac.dominio;



namespace Perfilac.dao
{
    public class ProductoDao:DaoGenerico
    {
        

        public ProductoDao():base()
        {
            
        }
        public List<Producto> consultarPorParametros(String codigo, int noFicha, TipoProducto tipo, TipoEnchape enchape)
        {
            String cadena = "SELECT TProducto.*,NTipo.id, NTipo.nombre as tipoProducto,NTipoEnchape.id,NTipoEnchape.nombre as tipoEnchape FROM ((TProducto INNER JOIN NTipo ON NTipo.id = TProducto.tipo) inner join NTipoEnchape on TProducto.enchape = NTipoEnchape.id) Where TProducto.id <> -1 ";
            //String cadena = "SELECT TProducto.* FROM ((TProducto INNER JOIN NTipo ON NTipo.id = TProducto.tipo) inner join NTipoEnchape on TProducto.enchape = NTipoEnchape.id) Where TProducto.tipo = " + tipo.Id + " and TProducto.enchape = " + enchape.Id + " ";

            if (tipo != null)
                cadena += "and TProducto.tipo = " + tipo.Id + "";
            if (enchape != null)
                cadena += "and TProducto.enchape = " + enchape.Id + "";
            if (codigo != "")
                cadena += "and TProducto.codigo like '" + codigo + "%'";
            if (noFicha != -1)
                cadena += "and TProducto.noFicha like '"+ noFicha + "%'";

       
            OdbcConnection conect = daoConection.getConexion();
            OdbcCommand command = conect.CreateCommand();
            List<Producto> result = new List<Producto>();
            command.CommandText = cadena;
            try
            {
                conect.Open();                
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);


                while (reader.Read())
                {
                    TipoEnchape tEnchape = new TipoEnchape((String)reader["tipoEnchape"]);
                    TipoProducto tProducto = new TipoProducto((String)reader["tipoProducto"]);
                    Producto nuevo = new Producto((String)reader["codigo"], (String)reader["descripcion"], int.Parse(reader["noFicha"].ToString()), double.Parse(reader["precioCUC"].ToString()), double.Parse(reader["precioCUP"].ToString()), (String)reader["suministrador"], (String)reader["color"],tEnchape,tProducto);
                    nuevo.Id = int.Parse(reader["id"].ToString());
                    result.Add(nuevo);
                }
                reader.Close();

                conect.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;


        }

        public void salvarProducto (Producto producto)
        {
            OdbcConnection conect = daoConection.getConexion();
            OdbcCommand command = conect.CreateCommand();
            command.CommandText = "insert into TProducto(codigo,enchape,tipo,descripcion,noFicha,precioCUP,precioCUC,suministrador,color) values('" + producto.Codigo + "','" + producto.Enchape.Id + "','" + producto.Tipo.Id + "','" + producto.Descripcion + "','" + producto.NoFicha + "','" + producto.PrecioCUP + "','" + producto.PrecioCUC + "','" + producto.Suministrador + "','" + producto.Color + "');";
            
            conect.Open();
            OdbcTransaction tx =  conect.BeginTransaction();
            command.Transaction = tx;

            try
            {
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                tx.Commit();          

               
                reader.Close();

                conect.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tx.Rollback();
            }

        }


	
    }
}
