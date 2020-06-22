using BeerService.Application.DTO.DataTransferObjects;
using BeerService.Application.DTO.Validators;
using BeerService.Application.Interfaces;
using BeerService.Application.Services;
using BeerService.Bus;
using BeerService.Data.Contexts;
using BeerService.Data.Repositories;
using BeerService.Data.UnitOfWork;
using BeerService.Domain.CommandHandlers;
using BeerService.Domain.Commands;
using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using BeerService.Domain.Interfaces.Repositories;
using BeerService.Domain.Interfaces.UnitOfWork;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BeerService.IoC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.InstallRepository();
            services.InstallUnitOfWork();
            services.InstallBus();
            services.InstallServices();
            services.InstallDataBaseContext();
            services.InstallEvents();
            services.InstallCommands();
            services.InstallValidators();

            return services;
        }

        private static void InstallRepository(this IServiceCollection services)
        {
            services.AddScoped<ICervejaRepository, CervejaRepository>();
        }

        private static void InstallUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void InstallBus(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }

        private static void InstallServices(this IServiceCollection services)
        {
            services.AddScoped<ICervejaAppService, CervejaAppService>();
        }

        private static void InstallDataBaseContext(this IServiceCollection services)
        {
            services.AddDbContext<MainContext>();
        }

        private static void InstallEvents(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        private static void InstallCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CadastrarCervejaCommand, bool>, CervejaCommandHandler>();
            services.AddScoped<IRequestHandler<EditarCervejaCommand, bool>, CervejaCommandHandler>(); 
            services.AddScoped<IRequestHandler<ExcluirCervejaCommand, bool>, CervejaCommandHandler>();
        }

        private static void InstallValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CadastrarCervejaDTO.Envio>, CadastrarCervejaDTOValidator>();
            services.AddScoped<IValidator<EditarCervejaDTO.Envio>, EditarCervejaDTOValidator>();
            services.AddScoped<IValidator<ExcluirCervejaDTO.Envio>, ExcluirCervejaDTOValidator>();
            services.AddScoped<IValidator<ConsultarCervejaDTO.Envio>, ConsultarCervejaDTOValidator>();
        }
    }
}