using System.Linq;
using The.Machine.Entities;

namespace The.Machine.Services
{
    public interface IDrinkRepository
    {
        IQueryable<Drink> Get(string query);
    }
}
