using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Context;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalcSka.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoController : ControllerBase
    {
        private readonly ILogger<HistoricoController> _logger;
        private readonly UnitOfWork _context;

        public HistoricoController(ILogger<HistoricoController> logger, UnitOfWork context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        public IEnumerable<CalculoHistoricoModel> Get()
        {
            var data = _context.CalculoHistorico.AsQueryable();
            return _context.CalculoHistorico.AsQueryable().ToArray();
        }
    }
}
