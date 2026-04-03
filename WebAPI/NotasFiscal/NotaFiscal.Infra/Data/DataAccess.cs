using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NotaFiscal.Domain.Dto;
using NotaFiscal.Infra.Data.Interfaces;
using NotaFiscal.Infra.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal.Infra.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public DataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public List<NotaFiscalViewDto> NotaFiscaisPorMes(int mes)
        {
            List<NotaFiscalViewDto> notasFiscais = new List<NotaFiscalViewDto>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = StoredProcedure.BuscarNotasPorMes;
                command.Parameters.AddWithValue("@MES", mes);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var notaFiscal = new NotaFiscalViewDto
                        {
                            CodNota = Convert.ToInt32(reader["CODNOTA"]),
                            NumNota = Convert.ToInt64(reader["NUMNOTA"]),
                            DtEmissao = Convert.ToDateTime(reader["DTEMISSAO"]),
                            ValorTotalNota = Convert.ToDecimal(reader["VALORTOTALNOTA"]),
                            CodItem = Convert.ToInt32(reader["CODITEM"]),
                            Qtde = Convert.ToInt32(reader["QTDE"]),
                            ValorTotal = Convert.ToDecimal(reader["VALORTOTAL"])
                        };
                        notasFiscais.Add(notaFiscal);
                    }
                }
            }

            return notasFiscais;
        }
    }

}

