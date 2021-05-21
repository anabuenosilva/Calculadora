using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Context;
using DataModel.Models;
using DataModel.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalcSka.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaveController : ControllerBase
    {
        private readonly ILogger<SaveController> _logger;
        private readonly UnitOfWork _context;

        public SaveController(ILogger<SaveController> logger, UnitOfWork context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CalculoHistoricoModel viewModel)
        {
            var model = new CalculoHistoricoModel();
            model.Operacao = viewModel.Operacao;
            model.ValorPrimario = viewModel.ValorPrimario;
            model.ValorSecundario = viewModel.ValorSecundario;
            model.DataCriacao = DateTime.Today;
            switch (viewModel.Operacao)
            {
                case Operacoes.Adicao:
                    model.Resultado = viewModel.ValorPrimario + viewModel.ValorSecundario;
                    model.Calculo = viewModel.ValorPrimario.ToString() + " + " + viewModel.ValorSecundario.ToString();
                    break;
                case Operacoes.Subtracao:
                    model.Resultado = viewModel.ValorPrimario - viewModel.ValorSecundario;
                    model.Calculo = viewModel.ValorPrimario.ToString() + " - " + viewModel.ValorSecundario.ToString();
                    break;
                case Operacoes.Multiplicacao:
                    model.Resultado = viewModel.ValorPrimario * viewModel.ValorSecundario;
                    model.Calculo = viewModel.ValorPrimario.ToString() + " x " + viewModel.ValorSecundario.ToString();
                    break;
                case Operacoes.Divisao:
                    model.Resultado = viewModel.ValorPrimario / viewModel.ValorSecundario;
                    model.Calculo = viewModel.ValorPrimario.ToString() + " ÷ " + viewModel.ValorSecundario.ToString();
                    break;
            }
            // alterar para usuario do sistema.
            model.Usuario = "UsuarioXYZ";
            _context.CalculoHistorico.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }
    }
}
