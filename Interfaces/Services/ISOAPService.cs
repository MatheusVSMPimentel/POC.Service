using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POC.Service.Models.DTOs;
using POC.Service.Models.XMLs;

namespace POC.Service.Interfaces.Services
{
    public interface ISOAPService
    {
        Task<AddResponseModel?> GetFreeWebServiceAdd(SOAPRequest request);
    }
}