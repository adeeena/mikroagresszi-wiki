using Microsoft.AspNetCore.Mvc;
using Mikroagresszi.Logic.BusinessLogic.Interfaces;
using Mikroagresszi.Logic.Models;
using MikroagressziWiki.Domain.Models;

namespace MikroagressziWiki.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly ICategoryLogic _categoryLogic;

        public CategoryController(ILogger<CategoryController> logger, ICategoryLogic categoryLogic)
        {
            _logger = logger;
            _categoryLogic = categoryLogic;
        }

        [HttpGet("getAll")]
        public IEnumerable<CategoryModel> Get()
        {
            return _categoryLogic.GetAll();
        }
    }
}