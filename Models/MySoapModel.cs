using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POC.Service.Models
{
    public class MySoapModel
    {

        [XmlElement("a")]

        public int Number1 { get; set; }
        [XmlElement("b")]
        public int Number2 { get; set; }

        public MySoapModel(int number1, int number2)
        {
            Number1 = number1;
            Number2 = number2;

        }
        
        public MySoapModel()
        {


        }
    }
}