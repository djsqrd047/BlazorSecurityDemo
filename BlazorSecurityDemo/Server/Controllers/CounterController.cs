using BlazorSecurityDemo.Shared;
using BlazorSecurityDemo.Repo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorSecurityDemo.Server.Controllers
{

    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        private readonly ILogger<CounterController> _logger;
        private readonly ICounterRepo _counterRepo;

        public CounterController(ILogger<CounterController> logger, ICounterRepo counterRepo)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            _counterRepo = counterRepo ?? throw new ArgumentNullException(nameof(counterRepo));
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<CurrentCount> Get()
        {
            return _counterRepo.GetCurrentCount();
        }

        [Authorize]
        [HttpPost]
        public IEnumerable<CurrentCount> Post([FromBody] int id)
        {
            return _counterRepo.IncrementCount(id);
        }
    }
}
