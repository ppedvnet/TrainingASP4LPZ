using Snacklager.Data;
using System.Collections.Generic;

namespace Snacklager.Logic.Contracts
{
    public interface ISnackRepository : IRepository<Snack>
    {
        IEnumerable<Snack> GetTopSnacks();
    }
}
