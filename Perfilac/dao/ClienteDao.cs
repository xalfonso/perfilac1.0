using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.Odbc;
using Perfilac.dominio;

namespace Perfilac.dao
{
    public class ClienteDao:DaoGenerico
    {
        
        
        
        public ClienteDao():base()
        {

        }
        public List<PersonaCliente> obtenerPersonasClientes(Cliente cliente)
        {
            String cadena = "SELECT * from TPersonaCliente Where TPersonaCliente.cliente ="+ cliente.Id +"";
            OdbcConnection conect = daoConection.getConexion();
            OdbcCommand command = conect.CreateCommand();            
            command.CommandText = cadena;
            List<PersonaCliente> result = new List<PersonaCliente>();
            try
            {
                conect.Open();
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);

                while (reader.Read())
                {

                    PersonaCliente nuevo = new PersonaCliente(reader["primerNombre"].ToString(), reader["segundoNombre"].ToString(), reader["primerApellido"].ToString(), reader["segundoApellido"].ToString(), reader["ci"].ToString(), reader["telefono"].ToString(), reader["cargo"].ToString());
                    nuevo.Id = int.Parse(reader["id"].ToString());
                    result.Add(nuevo);
                }
                reader.Close();

                conect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return result;

        }
        public List<Cliente> obtenerTodosClientes()
        {
            String cadena = "SELECT * from TCliente";
            OdbcConnection conect = daoConection.getConexion();
            OdbcCommand command = conect.CreateCommand();
           
            command.CommandText = cadena;
            List<Cliente> result = new List<Cliente>();
            try
            {
                conect.Open();
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);


                while (reader.Read())
                {

                    Cliente nuevo = new Cliente(reader["codigo"].ToString(), reader["nombre"].ToString(), reader["contrato"].ToString(), reader["direccion"].ToString(), null, reader["cuentaCUP"].ToString(), reader["cuentaCUC"].ToString());
                    nuevo.Id = int.Parse(reader["id"].ToString());
                    result.Add(nuevo);
                }
                reader.Close();

                conect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

            return result;
        }

        private void salvarPersonaCliente(PersonaCliente personaCliente)
        {
            //OdbcConnection conect = daoConection.getConexion();
            OdbcCommand command = this.Conect.CreateCommand();
            command.CommandText = "insert into TPersonaCliente(primerNombre,segundoNombre,primerApellido,segundoApellido,cliente,ci,telefono,cargo) values('" + personaCliente.PrimerNombre + "','" + personaCliente.SegundoNombre + "','" + personaCliente.PrimerApellido + "','" + personaCliente.SegundoApellido + "','" + personaCliente.Cliente.Id + "','" + personaCliente.CI + "','" + personaCliente.Telefono + "','" + personaCliente.Cargo + "');";

            
            //OdbcTransaction tx = conect.BeginTransaction();
            command.Transaction = this.Transaction;

            try
            {
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);
                //tx.Commit();


                reader.Close();

                //conect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
           
        }

        public void salvarClienteCompleto(Cliente cliente)
        {
            
            this.Conect = daoConection.getConexion();
            this.Conect.Open();
            OdbcCommand command = this.Conect.CreateCommand();
            this.Transaction = this.Conect.BeginTransaction();
            salvarCliente(cliente);
            int idCliente = 0;


            command.CommandText = "Select max(id) from TCliente";
            command.Transaction = this.Transaction;
           
            try
            {
                
                idCliente = int.Parse(command.ExecuteScalar().ToString());
                Console.WriteLine(command.CommandText);

                //reader.ToString();
                //int a = reader.FieldCount;
                
                //idCliente = int.Parse(reader[1].ToString());
                //while (reader.Read())
                //{
                //    idCliente = int.Parse(reader[0].ToString());
                //}
                //reader.Close();

                //conect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
            
            
            foreach (PersonaCliente var in cliente.Comerciales)
            {
                var.Cliente.Id = idCliente;
                salvarPersonaCliente(var);
            }
            this.Transaction.Commit();
            this.Conect.Close();
        }

        private void salvarCliente(Cliente cliente)
        {
            //OdbcConnection conect = daoConection.getConexion();
            OdbcCommand command = this.Conect.CreateCommand();   
            
          
            command.CommandText = "insert into TCliente(codigo,nombre,contrato,direccion,cuentaCUP,cuentaCUC) values('" + cliente.Codigo + "','" + cliente.Nombre + "','" + cliente.Contrato + "','" + cliente.Direccion + "','" + cliente.CuentaCUP + "','" + cliente.CuentaCUC + "');";
           
            //conect.Open();
            //OdbcTransaction tx = conect.BeginTransaction();
            command.Transaction = this.Transaction;        
           
            try
            {
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);

                //tx.Commit();
               
                reader.Close();

                //conect.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }

           
        }
    }
}
