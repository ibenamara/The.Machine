using The.Machine.Entities;

namespace The.Machine.Services
{
    public interface IEmployeeRepository
    {
        Employee GetById(long id);
        bool Create(Employee document);
        bool Update(Employee document);
    }
}
