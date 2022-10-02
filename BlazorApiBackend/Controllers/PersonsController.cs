

namespace BlazorApiBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        #region fields

        private readonly ILogger _logger;
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
        public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
        {
            try
            {
                _logger.LogInformation("GetAll request");

                var result = await _personService.GetAllAsync();

                _logger.LogInformation($"Returned {result.Count()} persons ");

                return result.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return Problem(detail:null);
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto?>> Get(string id)
        {
            (bool personFound, PersonDto? person) = await _personService.TryGetByIdAsync(id); //Wait for result and destruct Tuple

            if (!personFound)
            {
                return NotFound();
            }

            return person;
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<ActionResult<PersonDto?>> Post([FromBody] PersonDto person)
        {
            if (person.Id != null)
                return BadRequest("The DTO identifier must not have identifier in the body.");

            return await _personService.InsertAsync(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDto?>> Put(string id, [FromBody] PersonDto person)
        {
            if(person.Id != id)
                return BadRequest("The DTO identifier does not match the identifier in the route.");

            PersonDto? updatedPerson = await _personService.UpdateAsync(id, person);

            if (updatedPerson == null)
                return NotFound("The DTO identifier was not found.");

            return updatedPerson;
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
