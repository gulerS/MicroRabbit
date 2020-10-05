using System.Collections.Generic;
using Microrabbit.Transfer.Domain.Models;

namespace Microrabbit.Transfer.Domain.Interfaces {
    public interface ITransferRepository {
        IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
