using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public object GetBy([FromQuery] string categoryId)
        {
            var category = _context.Categories.SingleOrDefault(q => q.Id == categoryId);
            var entries = _context.Entries
                .Where(q => q.Categories.Any(w => w.Id == categoryId)).ToList();

            return new
            {
                Name = category.Name,
                Description = category.Description,
                Entries = entries
            };
        }

        [HttpGet("getById")]
        public object GetById([FromQuery] string entryId)
        {
            var entry = _context.Entries
                .Include(q => q.Categories)
                .Include(q => q.Entryresources)
                .SingleOrDefault(q => q.Id == entryId));

            foreach (var c in entry.Categories)
            {
                c.Entries = null;
            }

            return entry;
        }
    }
}