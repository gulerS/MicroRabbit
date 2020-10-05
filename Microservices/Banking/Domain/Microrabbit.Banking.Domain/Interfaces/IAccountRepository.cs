using System.Collections.Generic;
using Microrabbit.Banking.Domain.Models;

namespace Microrabbit.Banking.Domain.Interfaces {
    public interface IAccountRepository {
        IEnumerable<Account> GetAccounts();
    }
}
