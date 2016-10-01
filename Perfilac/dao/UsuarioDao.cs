using System;
using System.Collections.Generic;
using System.Text;
using Perfilac.dominio;
using System.Data.Common;
using System.Data.Odbc;
namespace Perfilac.dao
{
    public class UsuarioDao:DaoGenerico
    {

        public List<Usuario> listarUsuarios()
        {
            this.Conect = daoConection.getConexion();
            this.Conect.Open();
            OdbcCommand command = this.Conect.CreateCommand();
            this.Transaction = this.Conect.BeginTransaction();
            command.Transaction = this.Transaction;
            command.CommandText = "Select * from TUsuario";

            List<Usuario> listUsuarios = new List<Usuario>();
            try
            {
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);

                while (reader.Read())
                {
                    Usuario usuario = new Usuario(reader["usuario"].ToString(), reader["pass"].ToString(), reader["primerNombre"].ToString(), reader["segundoNombre"].ToString(), reader["primerApellido"].ToString(), reader["segundoApellido"].ToString());
                    usuario.Id = (int)reader["id"];
                    listUsuarios.Add(usuario);

                }

                reader.Close();

                this.Transaction.Commit();
             
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
            this.Conect.Close();
            return listUsuarios;
        }
        public void eliminarUsuario(int idUsuario)
        {
            this.Conect = daoConection.getConexion();
            this.Conect.Open();
            OdbcCommand command = this.Conect.CreateCommand();
            this.Transaction = this.Conect.BeginTransaction();
            command.Transaction = this.Transaction;
            command.CommandText = "DELETE FROM TUsuario WHERE TUsuario.id="+idUsuario+";";

            try
            {
                OdbcDataReader rea = command.ExecuteReader();
                Console.WriteLine(command.CommandText);

                rea.Close();
                this.Transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
            this.Conect.Close();

        }

        public void modificarUsuario(Usuario usuario)
        {
            this.Conect = daoConection.getConexion();
            this.Conect.Open();
            OdbcCommand command = this.Conect.CreateCommand();
            this.Transaction = this.Conect.BeginTransaction();
            command.Transaction = this.Transaction;                        
            command.CommandText = "UPDATE TUsuario SET TUsuario.primerNombre = '" + usuario.PrimerNombre + "', TUsuario.segundoNombre = '" + usuario.SegundoNombre + "', TUsuario.primerApellido = '" + usuario.PrimerApellido + "', TUsuario.segundoApellido = '" + usuario.SegundoApellido + "', TUsuario.usuario = '" + usuario.User + "', TUsuario.pass = '" + usuario.Pass + "'  WHERE TUsuario.id=" + usuario.Id + ";";
            
            try
            {
                OdbcDataReader rea = command.ExecuteReader();
                Console.WriteLine(command.CommandText);

                rea.Close();
                this.Transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
            this.Conect.Close();
        }
        public void salvarUsuario(Usuario usuario)
        {
            this.Conect = daoConection.getConexion();
            this.Conect.Open();
            OdbcCommand command = this.Conect.CreateCommand();
            this.Transaction = this.Conect.BeginTransaction();
            command.Transaction = this.Transaction;
            command.CommandText = "insert into TUsuario(usuario,pass,primerNombre,segundoNombre,primerApellido,segundoApellido) values('" + usuario.User + "','" + usuario.Pass + "','" + usuario.PrimerNombre + "','" + usuario.SegundoNombre + "','" + usuario.PrimerApellido + "','" + usuario.SegundoApellido + "')";

            try
            {
                OdbcDataReader reader = command.ExecuteReader();
                Console.WriteLine(command.CommandText);

                reader.Close();
                this.Transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Transaction.Rollback();
            }
            this.Conect.Close();
 
        }


    }
}
