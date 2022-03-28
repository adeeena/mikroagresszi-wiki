using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mikroagresszi.Logic.BusinessLogic.Interfaces;
using Mikroagresszi.Logic.Models;
using MikroagressziWiki.Api.DTOs;
using MikroagressziWiki.Core.Extensions;

namespace MikroagressziWiki.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        #region Properties

        private readonly ICategoryLogic _categoryLogic;

        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public CategoryController(
            ICategoryLogic categoryLogic,
            IMapper mapper)
        {
            _categoryLogic = categoryLogic;
            _mapper = mapper;
        }

        #endregion

        #region Exposed endpoints

        [HttpGet("getAll")]
        public IEnumerable<CategoryDto> Get()
        {
            IList<CategoryModel> categories = _categoryLogic.GetAll();

            return _mapper.MapCollection<CategoryModel, CategoryDto>(categories);
        }

        #endregion

    }
}