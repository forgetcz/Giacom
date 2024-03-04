using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GiacomApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrdDtaController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly ILogger<CrdDtaController> _logger;

        private IBaseDbRepository<CrdData, long> CrdDataRepository
        {
            get
            {
                return _dataService.GetCrdDataRepository();
            }
        }

        public CrdDtaController(ILogger<CrdDtaController> logger, IDataService service)
        {
            _logger = logger;
            _dataService = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CrdData>> Get(long id)
        {
            var todoItem = await CrdDataRepository.GetById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            else
            {
                return todoItem;
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var todoItem = await CrdDataRepository.Delete(id);
            if (todoItem == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }

        }
    }
}
