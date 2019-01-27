using Microsoft.Extensions.Logging;
using System.Linq;
using The.Machine.Entities;

namespace The.Machine.Services
{
    public class DrinkRepository : IDrinkRepository
    {
        TheMachineContext _context;
        ILogger<Drink> _logger;
        public DrinkRepository(TheMachineContext context, ILogger<Drink> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IQueryable<Drink> Get(string query = "")
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                return _context.Drinks.Where(x => x.Name == query).OrderBy(x => x.Id);
            }
            return _context.Drinks.OrderBy(x => x.Id);
        }
    }
}
