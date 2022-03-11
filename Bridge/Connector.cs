using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace ChequeBookService.Bridge
{
    public class Connector
    {
        public static OracleConnection getOracleConnection(string connString)
        {
            return (createOracleConnection(connString));
        }
        public static OracleConnection createOracleConnection(string connString)
        {
            var conn = new OracleConnection(connString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    return conn;
                }
                else { return conn = null; }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return null;
            }
        }
    }
}
