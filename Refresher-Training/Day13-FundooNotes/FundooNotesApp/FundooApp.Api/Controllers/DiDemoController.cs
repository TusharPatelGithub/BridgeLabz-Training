using Business.Interface;
using Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace FundooApp.Api.Controllers
{
    [ApiController]
    [Route("api/di-demo")]
    public class DiDemoController : ControllerBase
    {
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly OperationLogger _logger;

        public DiDemoController(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            OperationLogger logger)
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetLifetimes()
        {
            return Ok(new
            {
                message = "Reload this endpoint a few times to see how each lifetime behaves.",
                controller = new
                {
                    transient = _transientOperation.OperationId,
                    scoped = _scopedOperation.OperationId,
                    singleton = _singletonOperation.OperationId
                },
                loggerService = new
                {
                    transient = _logger.TransientOperation.OperationId,
                    scoped = _logger.ScopedOperation.OperationId,
                    singleton = _logger.SingletonOperation.OperationId
                },
                howToRead = new[]
                {
                    "transient: different GUID in 'controller' vs 'loggerService' EVEN in this same request - a new instance is created every time it's requested.",
                    "scoped: SAME GUID in 'controller' and 'loggerService' for this request, but changes on the NEXT request - one instance per request.",
                    "singleton: SAME GUID always, even across requests, for as long as the app keeps running - one instance for the whole app lifetime."
                }
            });
        }
    }
}
