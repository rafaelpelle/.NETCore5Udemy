using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore5Udemy.Model;
using NETCore5Udemy.Services.Implementations;

namespace NETCore5Udemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Person person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            Person result = _personService.Update(person);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}
