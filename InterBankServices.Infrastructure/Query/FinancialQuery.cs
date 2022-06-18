using InterBankServices.Application.Interfaces.Query;
using InterBankServices.Core.Entities;
using InterBankServices.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Infrastructure.Query
{
    public class FinancialQuery : IFinancialQuery
    {
        #region ATRIBUTOS
        private readonly string conStr;
        #endregion

        #region CONTRUCTOR
        public FinancialQuery(DbConnection connection)
        {
            conStr = connection.ConectionString;
        }
        #endregion

        #region METODOS
        public async Task<List<FinancialTypeEntity>> ListFinancialType()
        {
            string query = string.Format(@"SELECT id, description FROM BNBInterbank.bank.financial_type ");
          
            var ListFinancialType = new List<FinancialTypeEntity>();
            using (var connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    {

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListFinancialType.Add(item: new FinancialTypeEntity
                            {
                                id = Convert.ToInt32(reader["id"].ToString()),
                                description = reader["description"].ToString()
                            });
                        }
                        return ListFinancialType;

                    }
                }
                catch (Exception e)
                {
                    return ListFinancialType;
                }
                finally
                {
                    // Close the connection
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public async Task<List<FinancialTypeEntity>> ListFinancialTypeId(int id)
        {
            string query = string.Format(@"SELECT id, description FROM BNBInterbank.bank.financial_type WHERE id=@id ");

            var ListFinancialType = new List<FinancialTypeEntity>();
            using (var connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@id", id);
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListFinancialType.Add(item: new FinancialTypeEntity
                            {
                                id = Convert.ToInt32(reader["id"].ToString()),
                                description = reader["description"].ToString()
                            });
                        }
                        return ListFinancialType;

                    }
                }
                catch (Exception e)
                {
                    return ListFinancialType;
                }
                finally
                {
                    // Close the connection
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }
        #endregion
    }
}
