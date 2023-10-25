using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace POC.Service.Utils
{
    public class XmlParser
    {
        
        public T? ParseXmlToModel<T>(string? soapResponse) where T : class
        {
            if (string.IsNullOrWhiteSpace(soapResponse))
            {
                return null;
            }

            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var reader = new StringReader(soapResponse))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na desserialização: " + ex.Message);
                return null;
            }
        }

        public string ParseModelToXmlString<T>(T soapModel)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var xmlStringBuilder = new StringBuilder();
                using (var writer = new System.IO.StringWriter(xmlStringBuilder))
                {
                    serializer.Serialize(writer, soapModel);
                }
                return xmlStringBuilder.ToString();

            }
            catch (Exception ex)
            {
                // Trate exceções de desserialização, se necessário
                Console.WriteLine("Erro na desserialização: " + ex.Message);
                return null;
            }
        }
    }
}