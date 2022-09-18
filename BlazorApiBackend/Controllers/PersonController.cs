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
        private readonly IConfiguration _configuration;

        #endregion

        #region constructor

        public PersonController(IPersonService personService, ILogger<PersonController> logger, IConfiguration configuration)
        {
            _personService = personService;
            _logger = logger;
            _configuration = configuration;
        }

        #endregion

        #region APIs

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var result = await _personService.GetAllAsync();
            return result.ToList();
        }


        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person?>> Get(int id)
        {
            (bool personFound, Person? person) = await _personService.TryGetByIdAsync(id); //Wait for result and destruct Tuple

            if (!personFound)
            {
                return NotFound(); 
            }

            return person;
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<Person?>> Post([FromBody] Person person)
        {
            return await _personService.InsertAsync(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Person?>> Put(int id, [FromBody] Person person)
        {
            return await _personService.UpdateAsync(person);
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
