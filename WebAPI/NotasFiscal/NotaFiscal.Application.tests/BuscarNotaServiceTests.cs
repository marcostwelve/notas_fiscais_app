using Moq;
using NotaFiscal.Application.Services;
using NotaFiscal.Domain.Dto;
using NotaFiscal.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal.Application.tests
{
    public class BuscarNotaServiceTests
    {
        [Fact]
        public async Task Deve_Retornar_Notas_Quando_Mes_Valido()
        {
            var mockDataAccess = new Mock<IDataAccess>();

            var notasFake = new List<NotaFiscalViewDto>
            {
                new NotaFiscalViewDto
                {
                    CodNota = 1,
                    NumNota = 12345,
                    DtEmissao = DateTime.Now,
                    ValorTotalNota = 100.00m,
                    CodItem = 1,
                    Qtde = 2,
                    ValorTotal = 200.00m
                }
            };

            mockDataAccess.Setup(da => da.NotaFiscaisPorMes(10)).Returns(notasFake);

            var service = new BuscaNotaService(mockDataAccess.Object);

            var result = await service.BuscarNotasPorMes(10);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(1, result[0].CodNota);
        }

        [Fact]
        public async Task Deve_Retornar_Lista_Vazia_Quando_Nao_Hover_Dados()
        {
            var mockDataAccess = new Mock<IDataAccess>();

            mockDataAccess.Setup(x => x.NotaFiscaisPorMes(4))
                .Returns(new List<NotaFiscalViewDto>());

            var service = new BuscaNotaService(mockDataAccess.Object);

            Assert.ThrowsAsync<Exception>(() => service.BuscarNotasPorMes(4));
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Quando_DataAccess_Falhar()
        {
            var mockDataAccess = new Mock<IDataAccess>();
            mockDataAccess.Setup(x => x.NotaFiscaisPorMes(5))
                .Throws(new Exception("Erro ao acessar dados"));

            var service = new BuscaNotaService(mockDataAccess.Object);

            await Assert.ThrowsAsync<Exception>(() => service.BuscarNotasPorMes(5));
        }
    }
}
