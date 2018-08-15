using System.Collections.Generic;
using System.Linq;
using Snacklager.Data;
using Snacklager.Logic.Contracts;

namespace Snacklager.Logic
{
    public class SnackRepository : Repository<Snack>, ISnackRepository
    {
        public IEnumerable<Snack> GetTopSnacks()
        {
            return _table.OrderBy(x => x.Lagerhaltung.Select(y => y.Einheiten)).ToList();
        }
    }
}
