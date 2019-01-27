using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using The.Machine.Entities;

namespace The.Machine.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        TheMachineContext _context;
        ILogger<Employee> _logger;
        public EmployeeRepository(TheMachineContext context, ILogger<Employee> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Create(Employee employee)
        {
            try
            {
                if(GetById(employee.Id) != null)
                {
                    return Update(employee);
                }

                _context.Employees.Add(employee);
                _context.Drinks.Attach(employee.Preference.Drink);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

        }

        public Employee GetById(long id)
        {
            return _context.Employees.AsNoTracking().Include(blog => blog.Preference)
                .Include(x=>x.Preference.Drink).FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                _context.Entry(employee.Preference.Drink).State = EntityState.Detached;
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
