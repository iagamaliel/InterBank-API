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
    public class CertificateQuery : ICertificateQuery
    {
        #region ATRIBUTOS
        private readonly string conStr;
        #endregion

        #region CONTRUCTOR
        public CertificateQuery(DbConnection connection)
        {
            conStr = connection.ConectionString;
        }
        #endregion

        #region METODOS
        public async
        Task<bool> ValidCertificate(ValidateCertificateResponse command)
        {
            string query = string.Format(@"SELECT asfi_code, serial_number, certificate FROM BNBInterbank.certificate.certificate WHERE asfi_code =@asfi_code AND serial_number =@serial_number ");

            var ListFinancialType = new List<CertificateRequestEntity>();
            using (var connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@asfi_code", command.asfi_code);
                        cmd.Parameters.AddWithValue("@serial_number", command.serial_number);
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListFinancialType.Add(item: new CertificateRequestEntity
                            {
                                asfi_code = reader["asfi_code"].ToString(),
                                serial_number = reader["serial_number"].ToString()
                            });
                        }
                        int contador = ListFinancialType.Count();
                        if (ListFinancialType.Count() > 0)
                        {

                            return true;
                        }
                        return false;

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

        public async Task<List<CertificateResponseEntity>> ListCertificate()
        {
            string query = string.Format(@"SELECT id,asfi_code,serial_number,created_date,validity_date,owner,certificate FROM certificate.certificate");

            var ListCertificate = new List<CertificateResponseEntity>();
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
                            ListCertificate.Add(item: new CertificateResponseEntity
                            {
                                id = Convert.ToInt32(reader["id"].ToString()),
                                asfi_code = reader["asfi_code"].ToString(),
                                serial_number = reader["serial_number"].ToString(),
                                created_date = Convert.ToDateTime( reader["created_date"].ToString()),
                                validity_date = Convert.ToDateTime(reader["validity_date"].ToString()),
                                owner = reader["owner"].ToString()
                            });
                        }
                        return ListCertificate;

                    }
                }
                catch (Exception e)
                {
                    return ListCertificate;
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

        public async Task<List<CertificateResponseEntity>> ListCertificateId(int id)
        {
            string query = string.Format(@"SELECT id,asfi_code,serial_number,created_date,validity_date,owner,certificate FROM certificate.certificate WHERE id=@id ");

            var ListCertificate = new List<CertificateResponseEntity>();
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
                            ListCertificate.Add(item: new CertificateResponseEntity
                            {
                                id = Convert.ToInt32(reader["id"].ToString()),
                                asfi_code = reader["asfi_code"].ToString(),
                                serial_number = reader["serial_number"].ToString(),
                                created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                                validity_date = Convert.ToDateTime(reader["validity_date"].ToString()),
                                owner = reader["owner"].ToString()
                            });
                        }
                        return ListCertificate;

                    }
                }
                catch (Exception e)
                {
                    return ListCertificate;
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
