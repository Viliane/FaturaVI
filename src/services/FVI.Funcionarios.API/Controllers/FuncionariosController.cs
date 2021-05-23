using FVI.Core.Mediator;
using FVI.Funcionarios.API.Applcation.Commands;
using FVI.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVI.Funcionarios.API.Controllers
{
    public class FuncionariosController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public FuncionariosController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("funcionario")]
        public async Task<ActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(
                new RegistrarFuncionarioCommand(Guid.NewGuid(), "Teste", "teste@teste.com", "02009253000"));

            return ResponseCustomizado(resultado);
        }
    }
}
