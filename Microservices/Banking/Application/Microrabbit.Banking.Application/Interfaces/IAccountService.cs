using System.Collections.Generic;
using Microrabbit.Banking.Application.Dtos;
using Microrabbit.Banking.Domain.Models;

namespace Microrabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransferDto accountTransferDto);
    }
}
