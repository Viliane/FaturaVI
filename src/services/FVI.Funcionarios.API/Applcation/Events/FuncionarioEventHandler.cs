using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FVI.Funcionarios.API.Applcation.Events
{
    public class FuncionarioEventHandler : INotificationHandler<FuncionarioRegistradoEvent>
    {
        public Task Handle(FuncionarioRegistradoEvent notification, CancellationToken cancellationToken)
        {
            //Enviar evento de confirmação
            return Task.CompletedTask;
        }
    }
}
