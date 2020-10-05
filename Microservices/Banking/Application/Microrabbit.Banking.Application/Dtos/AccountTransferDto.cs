using System;
using System.Collections.Generic;
using System.Text;

namespace Microrabbit.Banking.Application.Dtos
{
    public class AccountTransferDto
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }

        public decimal TransferAmount { get; set; }

    }
}
