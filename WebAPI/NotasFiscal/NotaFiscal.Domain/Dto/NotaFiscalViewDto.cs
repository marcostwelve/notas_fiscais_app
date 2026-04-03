using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal.Domain.Dto
{
    public class NotaFiscalViewDto
    {
        public int CodNota { get; set; }
        public long NumNota { get; set; }
        public DateTime DtEmissao { get; set; }
        public decimal ValorTotalNota { get; set; }
        public int CodItem { get; set; }
        public int Qtde { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
