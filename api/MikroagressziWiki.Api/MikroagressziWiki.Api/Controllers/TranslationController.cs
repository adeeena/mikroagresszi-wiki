using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mikroagresszi.Logic.BusinessLogic.Interfaces;
using MikroagressziWiki.Api.DTOs;
using MikroagressziWiki.Logic.BusinessLogic.Interfaces;
using MikroagressziWiki.Logic.Models;

namespace MikroagressziWiki.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {
        #region Properties

        private readonly ITranslationLogic _translationLogic;

        private readonly IMapper _mapper;

        #endregion

        #region ctor

        public TranslationController(ITranslationLogic entryLogic, IMapper mapper)
        {
            _translationLogic = entryLogic;
            _mapper = mapper;
        }

        #endregion

        #region Exposed endpoints

        [HttpGet("getBy")]
        public object GetBy([FromQuery] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
            {
                throw new ArgumentNullException(nameof(languageCode));
            }

            var result = _translationLogic.GetBy(languageCode);
            return result;// _mapper.Map<CategoryEntriesResultModel, CategoryEntriesResultDto>(result);
        }

        #endregion
    }
}