using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using The.Machine.Entities;
using The.Machine.Models;
using The.Machine.Services;

namespace The.Machine.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private ILogger<EmployeeDTO> _logger;
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;
        public EmployeeController(ILogger<EmployeeDTO> logger, IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(long id)
        {
            Employee employee = _employeeRepository.GetById(id);
            if (employee != null)
            {
                return Ok(_mapper.Map<EmployeeDTO>(employee));
            }
            return NotFound();
        }

         [HttpPost]
         public IActionResult CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if(employeeDTO == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool resutlt = _employeeRepository.Create(_mapper.Map<Employee>(employeeDTO));
            if (!resutlt)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool resutlt =  _employeeRepository.Update(_mapper.Map<Employee>(employeeDTO));
            if(!resutlt)
            {
                return BadRequest();
            }
           
            return Ok();
        }
    }
}
