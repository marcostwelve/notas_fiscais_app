using NotaFiscal.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal.Infra.Data.Interfaces
{
    public interface IDataAccess
    {
        List<NotaFiscalViewDto> NotaFiscaisPorMes(int mes);
    }
}
