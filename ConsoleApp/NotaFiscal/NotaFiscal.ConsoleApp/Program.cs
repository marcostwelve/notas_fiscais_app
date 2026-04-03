using Microsoft.Extensions.Configuration;
using NotaFiscal.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var service = new NotaFiscalService(connectionString);

            var xmlService = new XmlService();

            Console.Write("Digite o mês para buscar as notas fiscais (1-12): ");
            int mes = int.Parse(Console.ReadLine());

            var notas = await service.BuscarNotasFiscaisPorMes(mes);

            xmlService.GerarXml(notas);

            Console.WriteLine("XML gerado com sucesso! O Arquivo está na pasta Downloads");

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
