using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POC.Service.Models.XMLs
{
    [XmlRoot("addResponse", Namespace = "http://free-web-services.com/soap")]
    public class AddResponseModel
    {
        [XmlElement("sum")]
        public int Sum { get; set; }

        [XmlElement("time")]
        public double Time { get; set; }
    }
}
