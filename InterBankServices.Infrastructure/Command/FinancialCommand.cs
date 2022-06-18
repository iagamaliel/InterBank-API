using InterBankServices.Application.Interfaces.Commands;
using InterBankServices.Core.Entities;
using InterBankServices.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterBankServices.Infrastructure.Command
{
    public class FinancialCommand : IFinancialCommand
    {
        #region ATRIBUTOS
        private readonly string conStr;
        #endregion

        #region CONTRUCTOR
        public FinancialCommand(DbConnection connection)
        {
            conStr = connection.ConectionString;
        }
        #endregion

        #region METODOS

        public async Task<bool> CreateFinancialTypeRequestCommand(FinancialTypeEntity command)
        {

            string query = string.Format(@"INSERT INTO BNBInterbank.bank.financial_type (description) 
                                VALUES (@description)");

            using (var connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@description", command.description);
                        cmd.ExecuteNonQuery();

                        return true;

                    }
                }
                catch (Exception e)
                {
                    return false;
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


        public async Task<bool> ModifyFinancialTypeRequestCommand(FinancialTypeEntity command)
        {

            string query = string.Format(@"UPDATE BNBInterbank.bank.financial_type SET description = @description WHERE id = @id");

            using (var connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@description", command.description);
                        cmd.Parameters.AddWithValue("@id", command.id);
                        cmd.ExecuteNonQuery();

                        return true;

                    }
                }
                catch (Exception e)
                {
                    return false;
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
