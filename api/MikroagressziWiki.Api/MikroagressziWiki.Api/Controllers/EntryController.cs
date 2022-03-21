using Microsoft.AspNetCore.Mvc;
using MikroagressziWiki.Domain.Models;

namespace MikroagressziWiki.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly ILogger<EntryController> _logger;

        private readonly MikroagressziContext _context;

        public EntryController(ILogger<EntryController> logger, MikroagressziContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("categories")]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.OrderBy(q => q.Order).ToList();
        }

        [HttpGet("getBy")]
        public IEnumerable<Entry> GetBy([FromQuery] Guid categoryId)
        {
            var entries = _context.Entries.Where(q => q.Categories.Any(w => w.Id == categoryId.ToString())).ToList();

            return entries;
        }
    }
}