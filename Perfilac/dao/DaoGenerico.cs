using System;
using System.Collections.Generic;
using System.Text;
using Perfilac.origen_datos;
using System.Data.Odbc;

namespace Perfilac.dao
{
    public class DaoGenerico
    {
        protected DaoConecction daoConection;

        public DaoConecction DaoConection
        {
            get { return daoConection; }
            set { daoConection = value; }
        }

        protected OdbcConnection conec;

        public OdbcConnection Conect
        {
            get { return conec; }
            set { conec = value; }
        }

        protected OdbcTransaction transaction;

        public OdbcTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }
        public DaoGenerico()
        {
            this.daoConection = new DaoConecction();
        }

       
         
        
        
    }
}
