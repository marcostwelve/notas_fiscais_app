using NotaFiscal.Application.Services.Interfaces;
using NotaFiscal.Domain.Dto;
using NotaFiscal.Infra.Data.Interfaces;


namespace NotaFiscal.Application.Services
{
    public class BuscaNotaService : IBuscaNotaService
    {
        private readonly IDataAccess _dataAccess;
        public BuscaNotaService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<List<NotaFiscalViewDto>> BuscarNotasPorMes(int mes)
        {
            var notas = _dataAccess.NotaFiscaisPorMes(mes);

            if (notas == null || notas.Count == 0)
            {
                throw new Exception("Nenhuma nota fiscal encontrada para o mês especificado.");
            }

            return notas;
        }
    }
}
