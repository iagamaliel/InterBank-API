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
    public class CertificateCommand : ICertificateCommand
    {
        #region ATRIBUTOS
        private readonly string conStr;
        #endregion

        #region CONTRUCTOR
        public CertificateCommand(DbConnection connection)
        {
            conStr = connection.ConectionString;
        }
        #endregion

        #region METODOS

        public async Task<bool> CreateCertificateRequestCommand(CertificateRequestEntity command)
        {
           
                string query = string.Format(@"INSERT INTO BNBInterbank.certificate.certificate (asfi_code, serial_number, created_date, validity_date, owner, certificate) 
                                VALUES (@asfi_code, @serial_number, @created_date, @validity_date, @owner, @certificate)");

            using (var connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@asfi_code", command.asfi_code);
                    cmd.Parameters.AddWithValue("@serial_number", command.serial_number);
                    cmd.Parameters.AddWithValue("@created_date", command.created_date);
                    cmd.Parameters.AddWithValue("@validity_date", command.validity_date);
                    cmd.Parameters.AddWithValue("@owner", command.owner);
                    cmd.Parameters.AddWithValue("@certificate", command.certificate);
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
