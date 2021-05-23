using FluentValidation.Results;
using FVI.Core.Mediator;
using FVI.Funcionarios.API.Applcation.Commands;
using FVI.Funcionarios.API.Applcation.Events;
using FVI.Funcionarios.API.Data;
using FVI.Funcionarios.API.Data.Repository;
using FVI.Funcionarios.API.Models;
using FVI.Funcionarios.API.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVI.Funcionarios.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddScoped<INotificationHandler<FuncionarioRegistradoEvent>, FuncionarioEventHandler>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<FuncionariosContext>();

            services.AddHostedService<RegistroFuncionarioIntegrationHandler>();
        }
    }
}
