using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using POC.Service.Interfaces.Services;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using POC.Service.Models.XMLs;
using POC.Service.Models.DTOs;
using POC.Service.Models;
using POC.Service.Utils;


namespace POC.Service.Services
{
    public class SOAPService : ISOAPService
    {
        private readonly HttpClient _httpClient;
        private readonly XmlParser _xmlParser;

        public SOAPService(HttpClient httpClient, XmlParser xmlParser)
        {
            _httpClient = httpClient;
            _xmlParser = xmlParser;
        }
        public async Task<AddResponseModel?> GetFreeWebServiceAdd(SOAPRequest requestSOAP)
        {
            //TODO: A post with json to receive a json return
            // Configure the HTTP request
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://free-web-services.com/add?a={requestSOAP.Number1}&b={requestSOAP.Number2}");
            //request.Headers.Add("SOAPAction", "https://free-web-services.com/add");
            //request.Content = new StringContent(_xmlParser.ParseModelToXmlString<MySoapModel>(new MySoapModel(requestSOAP.Number1, requestSOAP.Number2)), Encoding.UTF8, "text/xml");

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = _xmlParser.ParseXmlToModel<AddResponseModel>(responseContent);
                return new AddResponseModel(){Sum = int.TryParse(responseContent, out int _response )? _response : 0} ; 
            }
            else
            {
                throw new Exception("SOAP request failed");
            }
        }
    }
}