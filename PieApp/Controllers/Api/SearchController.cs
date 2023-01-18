using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PieApp.Models;

namespace PieApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;
        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        [HttpGet]
        public IActionResult GetAll() 
        { 
          return Ok(_pieRepository.AllPies);
        }

        [HttpGet("{id}")]   
        public IActionResult GetById(int id) 
        {
          if(!_pieRepository.AllPies.Any(p => p.PieId == id))
                return NotFound();

            return Ok(_pieRepository.AllPies.Where(p => p.PieId == id));
        }

        [HttpPost]
        public IActionResult Search([FromBody] string stringQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>();    
            if(!string.IsNullOrEmpty(stringQuery))
            {
                pies = _pieRepository.SearchPies(stringQuery);
            }
            return new JsonResult(pies);    
        }
       
    }
}
