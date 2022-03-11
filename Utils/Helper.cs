using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Diagnostics;

using ChequeBookService.Data;
using ChequeBookService.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;

namespace ChequeBookService.Utils
{
    public class Helper
    {
        private ChequeBookServiceContext config;

        public Helper()
        {
            config = new ChequeBookServiceContext();
        }

        public async Task<IEnumerable<ChequeBook>> GetChequeBooksAsync(DateTime dt)
        {
            //method uses the date argument to fetch all cheque books generated for that day
            return await config.ChequeBooks.Where(c => c.DateUpload == dt).ToListAsync();
        }

        public List<ChequeBook> getChequeRecords(OracleConnection conn, string query)
        {
            List<ChequeBook> results = null;
            try
            {
                using (conn)
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 120;

                    using (var d = cmd.ExecuteReader())
                    {
                        if (d.HasRows)
                        {
                            results = new List<ChequeBook>();
                        }

                        while (d.Read())
                        {
                            try
                            {
                                var c = new ChequeBook();

                                c.ChqOrderDate = Convert.ToDateTime(d["CHQ_ORDER_DATE"].ToString());
                                c.AccountNumber = d["ACCOUNT_NO"].ToString();
                                c.AccountName = d["ACCOUNT_NAME"].ToString();
                                c.AccountClass = d["ACCOUNT_CLASS"].ToString();
                                c.ChequeType = d["CHEQUE_TYPE"].ToString();
                                c.Notes = d["NOTES"].ToString();
                                c.Leaves = d.IsDBNull("LEAVES") ? 0 : int.Parse(d["LEAVES"].ToString());
                                c.ChequeNumber = d["CHECK_NO"].ToString();
                                c.ReferenceId = d["REFERENCE_ID"].ToString();
                                c.ReferenceNo = d["REFERENCE_NO"].ToString();
                                c.BranchCode = d.IsDBNull("BRANCH_CODE") ? 0 : int.Parse(d["BRANCH_CODE"].ToString());
                                c.TelephoneNumber = d["TEL_NO"].ToString();

                                results.Add(c);
                            }
                            catch(Exception xx)
                            {

                            }
                        }
                    }
                }

                return results.ToList<ChequeBook>();
            }
            catch(Exception x)
            {
                throw x;
            }
        }

        public async Task<ConfigParam> getConfigObject(string strKey)
        {
            return await config.ConfigParams.FindAsync(strKey);
        }

        public async Task<string> getQueryString(string strResourcePath)
        {
            //gets the contents of a resource path
            return await File.ReadAllTextAsync(strResourcePath);
        }

    }
}
