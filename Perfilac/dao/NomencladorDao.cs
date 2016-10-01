using System;
using System.Collections.Generic;
using System.Text;
using Perfilac.dominio;
using Perfilac.origen_datos;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;


namespace Perfilac.dao
{
    public class NomencladorDao:DaoGenerico
    {
             

        public NomencladorDao():base()
        {
           
        }
        public List<TipoProducto> obtenerTiposProductos()
        {
            OdbcConnection conect = daoConection.getConexion();
            OdbcCommand command = conect.CreateCommand();
            //SqlCommand comand1 = conect.CreateCommand();           
            command.CommandText = "Select id,nombre from NTipo;";
            List<TipoProducto> result = new List<TipoProducto>();
            
            
            
            try
            {
                conect.Open();
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
               

                while (reader.Read())
                {
                    TipoProducto nuevo = new TipoProducto((String)reader["nombre"]);
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
        public List<TipoEnchape> obtenerTiposEnchapes()
        {
            OdbcConnection conect = daoConection.getConexion();
            OdbcCommand command = conect.CreateCommand();
            command.CommandText = "Select id,nombre from NTipoEnchape;";                  
            List<TipoEnchape> result = new List<TipoEnchape>();
            
                
           
             try
            {
                conect.Open(); 
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                

                while (reader.Read())
                {
                    TipoEnchape nuevo = new TipoEnchape((String)reader["nombre"]);
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
    }
}
