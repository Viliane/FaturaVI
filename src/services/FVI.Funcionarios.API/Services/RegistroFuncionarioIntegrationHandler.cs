using EasyNetQ;
using FluentValidation.Results;
using FVI.Core.Mediator;
using FVI.Core.Messages.Integration;
using FVI.Funcionarios.API.Applcation.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FVI.Funcionarios.API.Services
{
    public class RegistroFuncionarioIntegrationHandler : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroFuncionarioIntegrationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
                new ResponseMessage(await RegistrarFuncionario(request)));

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegistrarFuncionario(UsuarioRegistradoIntegrationEvent message)
        {
            var funcionarioCommand = new RegistrarFuncionarioCommand(message.Id, message.Nome, message.Email, message.Cpf);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(funcionarioCommand);
            }

            return sucesso;
        }
    }
}
