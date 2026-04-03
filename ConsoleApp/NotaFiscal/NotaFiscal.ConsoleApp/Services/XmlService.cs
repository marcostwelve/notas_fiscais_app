using NotaFiscal.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NotaFiscal.ConsoleApp.Services
{
    public class XmlService
    {
        public void GerarXml(List<Models.NotaFiscal> notasFiscais)
        {
            var lista = new NotaFiscalList()
            {
                NotasFiscais = notasFiscais
            };

            var downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            
            var fileName = $"notas_{DateTime.Now:yyyyMMdd_HHmmss}.xml";
            var filePath = Path.Combine(downloadPath, fileName);

            var serializer = new XmlSerializer(typeof(NotaFiscalList));

            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, lista);
            }
        }
    }
}
