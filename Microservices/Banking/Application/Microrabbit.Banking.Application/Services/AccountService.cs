using System.Collections.Generic;
using Microrabbit.Banking.Application.Dtos;
using Microrabbit.Banking.Application.Interfaces;
using Microrabbit.Banking.Domain.Commands;
using Microrabbit.Banking.Domain.Interfaces;
using Microrabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace Microrabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransferDto accountTransferDto)
        {
            var createTransferCommand = new CreateTransferCommand(
                                             accountTransferDto.FromAccount,
                                             accountTransferDto.ToAccount,
                                             accountTransferDto.TransferAmount
                                             );

            _bus.SendCommand(createTransferCommand);
        }
    }
}
