using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data.Common;

namespace Perfilac.origen_datos
{
      public class DaoConecction
      {

         static private OdbcConnection conexion;
         //static private String cadenaConexion = "Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=C:\\Documents and Settings\\ealfonso\\Mis documentos\\Codigo Perfilac\\Perfilac\\BD\\Perfilac.mdb;Uid=Eduardo;Pwd=Eduardo;";
         static private String cadenaConexion = "Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=..\\..\\..\\BD\\Perfilac.mdb;Uid=Eduardo;Pwd=Eduardo;"; 

          public OdbcConnection getConexion()
          {
              //if (conexion == null)
              //    conexion = new OdbcConnection(cadenaConexion);
              conexion = new OdbcConnection(cadenaConexion);  
              return conexion;
          } 
             
        
            
        

        
         
       
      }
}
