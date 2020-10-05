using System.Collections.Generic;
using Microrabbit.Banking.Data.Context;
using Microrabbit.Banking.Domain.Interfaces;
using Microrabbit.Banking.Domain.Models;

namespace Microrabbit.Banking.Data.Repository {
    public class AccountRepository : IAccountRepository {

        private readonly BankingDbContext _ctx;

        public AccountRepository(BankingDbContext ctx) {
            _ctx = ctx;
        }

        public IEnumerable<Account> GetAccounts() {
            return _ctx.Accounts;
        }
    }
}
