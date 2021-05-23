using FluentValidation.Results;
using FVI.Core.Messages;
using FVI.Funcionarios.API.Applcation.Events;
using FVI.Funcionarios.API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FVI.Funcionarios.API.Applcation.Commands
{
    public class FuncionarioCommandHandler : CommandHandler, IRequestHandler<RegistrarFuncionarioCommand, ValidationResult>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarFuncionarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var funcionario = new Funcionario(message.Id, message.Nome, message.Email, message.Cpf);

            var funcionarioExiste = await _funcionarioRepository.ObterPorCpf(funcionario.Cpf.Numero);

            if (funcionarioExiste != null)
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }

            _funcionarioRepository.Adicionar(funcionario);

            funcionario.AdicionarEvento(new FuncionarioRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

            return await PersistirDados(_funcionarioRepository.UnitOfWork);
        }
    }
}
