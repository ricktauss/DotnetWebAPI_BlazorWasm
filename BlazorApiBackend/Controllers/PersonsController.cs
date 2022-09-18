using BlazorApiBackend.Services;
using Microsoft.AspNetCore.Mvc;


namespace BlazorApiBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        #region fields

        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonService _personService;
        private readonly IConfiguration _configuration;

        #endregion

        #region constructor

        public PersonsController(IPersonService personService, ILogger<PersonsController> logger, IConfiguration configuration)
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
        public async Task<ActionResult<Person?>> Get(string id)
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
        public async Task<ActionResult<Person?>> Put(string id, [FromBody] Person person)
        {
            return await _personService.UpdateAsync(id, person);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _personService.DeleteAsync(id);
            return Ok();
        }

        #endregion
    }
}
