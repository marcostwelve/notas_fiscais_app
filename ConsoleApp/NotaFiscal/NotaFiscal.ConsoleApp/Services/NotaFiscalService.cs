using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal.ConsoleApp.Services
{
    public class NotaFiscalService
    {
        private readonly string _connectionString;

        public NotaFiscalService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Models.NotaFiscal>> BuscarNotasFiscaisPorMes(int mes)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@MES", mes);

                var result = await connection.QueryAsync<Models.NotaFiscal>(
                    "SP_BUSCAR_NOTAS_POR_MES",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                 );

                return result.ToList();
            }
        }
    }
}
