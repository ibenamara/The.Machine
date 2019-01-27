using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using The.Machine.Models;
using The.Machine.Services;

namespace The.Machine.Controllers
{
    [Route("api/drinks")]
    public class DrinksController : Controller
    {
        private ILogger<DrinkDTO> _logger;
        private IDrinkRepository _drinkRepository;
        private IMapper _mapper;
        public DrinksController(ILogger<DrinkDTO> logger, IDrinkRepository drinkRepository,
            IMapper mapper)
        {
            _logger = logger;
            _drinkRepository = drinkRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult GetAllDrinks(string query = "")
        {
          return Ok(_mapper.Map<IEnumerable<DrinkDTO>>(_drinkRepository.Get(query).ToList()));
        }
    }
}
