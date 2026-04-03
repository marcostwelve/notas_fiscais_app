using NotaFiscal.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal.Application.Services.Interfaces
{
    public interface IBuscaNotaService
    {
        Task<List<NotaFiscalViewDto>> BuscarNotasPorMes(int mes);
    }
}
