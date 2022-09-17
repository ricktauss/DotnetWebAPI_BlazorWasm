using BlazorApiBackend.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;


namespace BlazorApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region fields

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        #endregion

        #region constructor

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        #endregion

        #region APIs

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            return _personService.GetAll().ToList();
        }


        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<Person?> Get(int id)
        {
            if (!_personService.TryGetById(id, out var person))
            {
                return NotFound(); 
            }

            return person;
        }

        // POST api/<PersonController>
        [HttpPost]
        public ActionResult<Person?> Post([FromBody] Person person)
        {
            return _personService.Insert(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public ActionResult<Person?> Put(int id, [FromBody] Person person)
        {
            return _personService.Update(person);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personService.DeleteAsync(id);
            return Ok();
        }

        #endregion
    }
}
