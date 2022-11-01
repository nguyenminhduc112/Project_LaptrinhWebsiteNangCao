using blogAPI.Data;
using blogAPI.Dto.User;
using blogAPI.Responsitories;
using Microsoft.AspNetCore.Mvc;
namespace blogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleRespository _ArticleRespository;
        public ArticleController(ArticleRespository context)
        {
            _ArticleRespository = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListArticle()
        {

            var listArticle = await _ArticleRespository.GetArticles();

            return Ok(listArticle);
        }

        [HttpPost]
        public IActionResult addArticle(CreateArticleDto createArticleDto)
        {
            if (ModelState.IsValid)
            {
                var article = _ArticleRespository.InserArticle(new Models.Article()
                {
                    Title = createArticleDto.Title,
                    Content = createArticleDto.Content,
                    AuthorId = createArticleDto.AuthorId,
                });
                return Ok(article);
            }else{
                return BadRequest(ModelState.ErrorCount);
            }
        }
    }
}