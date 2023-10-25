using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POC.Service.Interfaces.Services;
using POC.Service.Models.DTOs;

namespace POC.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SOAPController : ControllerBase
    {
        private readonly ISOAPService _SOAPService;
        public SOAPController(ISOAPService SOAPService){
            _SOAPService = SOAPService;
        }

        [HttpPost()]
        public async Task<ActionResult> PostSoapAdd(SOAPRequest request){   
            return Ok(await _SOAPService.GetFreeWebServiceAdd(request));
        }
    }
}