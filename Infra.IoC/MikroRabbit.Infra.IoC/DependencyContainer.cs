using MediatR;
using Microrabbit.Banking.Application.Interfaces;
using Microrabbit.Banking.Application.Services;
using Microrabbit.Banking.Data.Context;
using Microrabbit.Banking.Data.Repository;
using Microrabbit.Banking.Domain.CommandHandlers;
using Microrabbit.Banking.Domain.Commands;
using Microrabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using Microrabbit.Transfer.Application.Interfaces;
using Microrabbit.Transfer.Application.Services;
using Microrabbit.Transfer.Data.Context;
using Microrabbit.Transfer.Data.Repository;
using Microrabbit.Transfer.Domain.EventHandlers;
using Microrabbit.Transfer.Domain.Events;
using Microrabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MikroRabbit.Infra.Bus;

namespace MikroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(),scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();
            
            
            // Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Aoplication Services 
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}