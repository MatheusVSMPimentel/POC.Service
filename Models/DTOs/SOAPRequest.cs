using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace POC.Service.Models.DTOs
{
    public class SOAPRequest
    {
        [JsonProperty("first")]
        public int Number1 { get; set; }
        [JsonProperty("second")]
        public int Number2 { get; set; }
    }
}