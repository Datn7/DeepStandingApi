using DeepStandingApi.Services.DI;
using Microsoft.AspNetCore.Mvc;

namespace DeepStandingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiTestController : ControllerBase
    {
        private readonly SingletonService _singleton;
        private readonly ScopedService _scoped;
        private readonly TransientService _transient;

        public DiTestController(
            SingletonService singleton,
            ScopedService scoped,
            TransientService transient)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                singleton = _singleton.GetOperationId(),
                scoped = _scoped.GetOperationId(),
                transient = _transient.GetOperationId()
            });
        }
    }
}
