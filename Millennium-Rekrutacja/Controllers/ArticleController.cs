using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Millennium_Rekrutacja.BindingModel;
using Millennium_Rekrutacja.BusinessLogic.Interface;

namespace Millennium_Rekrutacja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : BaseController
    {
        private readonly IArticleAddBusinessLogic _articleAddBusinessLogic;
        private readonly IArticleGetByIdBusinessLogic _articleGetByIdBusinessLogic;
        private readonly IArticleDeleteBusinessLogic _articleDeleteBusinessLogic;
        private readonly IArticleUpdateBusinessLogic _articleUpdateBusinessLogic;

        public ArticleController(IArticleAddBusinessLogic articleAddBusinessLogic, IArticleGetByIdBusinessLogic articleGetByIdBusinessLogic, IArticleDeleteBusinessLogic articleDeleteBusinessLogic, IArticleUpdateBusinessLogic articleUpdateBusinessLogic)
        {
            _articleAddBusinessLogic = articleAddBusinessLogic;
            _articleGetByIdBusinessLogic = articleGetByIdBusinessLogic;
            _articleDeleteBusinessLogic = articleDeleteBusinessLogic;
            _articleUpdateBusinessLogic = articleUpdateBusinessLogic;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ArticleBindingModel articleBindingModel)
        {
            var result = await _articleAddBusinessLogic.ExecuteAsync(articleBindingModel);

            return CreateResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _articleGetByIdBusinessLogic.ExecuteAsync(id);

            return CreateResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] ArticleBindingModel articleBindingModel)
        {
            var result = await _articleUpdateBusinessLogic.ExecuteAsync(new ArticleUpdateBindingModel
            {
                Id = id,
                Content = articleBindingModel.Content,
                Status = articleBindingModel.Status,
                Tags = articleBindingModel.Tags,
                Title = articleBindingModel.Title,
            });

            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var result = await _articleDeleteBusinessLogic.ExecuteAsync(id);

            return CreateResponse(result);
        }
    }
}