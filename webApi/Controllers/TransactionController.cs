using Domain.Domain.Interfaces.Services;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {        
        private readonly ILogger<TransactionController> _logger;
        private IInvoiceStatusService service;

        public TransactionController(ILogger<TransactionController> logger, IInvoiceStatusService service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<InvoiceStatus> Get()
        {
            return service.getAll();
        }
    }
}
