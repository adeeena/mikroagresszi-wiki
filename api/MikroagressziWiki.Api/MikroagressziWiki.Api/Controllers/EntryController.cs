using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MikroagressziWiki.Domain.Models;
using MikroagressziWiki.Logic.BusinessLogic.Interfaces;
using MikroagressziWiki.Logic.Models;

namespace MikroagressziWiki.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly ILogger<EntryController> _logger;

        private readonly IEntryLogic _entryLogic;

        public EntryController(ILogger<EntryController> logger, IEntryLogic entryLogic)
        {
            _logger = logger;
            _entryLogic = entryLogic;
        }

        [HttpGet("getBy")]
        public CategoryEntriesResultModel GetBy([FromQuery] string categoryId)
        {
            return _entryLogic.GetBy(categoryId);
        }

        [HttpGet("getById")]
        public object GetById([FromQuery] string entryId)
        {
            return _entryLogic.GetById(entryId);
        }

        [HttpGet("searchBy")]
        public object searchBy([FromQuery] string query)
        {
            return _entryLogic.SearchBy(query);
        }
    }
}