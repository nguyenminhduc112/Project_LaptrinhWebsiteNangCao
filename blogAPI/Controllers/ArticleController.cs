using blogAPI.Data;
using blogAPI.Dto.Article;
using blogAPI.Dto.User;
using blogAPI.Models;
using blogAPI.Responsitories;
using Microsoft.AspNetCore.Mvc;
namespace blogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleRespository _context;
        public ArticleController(ArticleRespository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListArticle()
        {

            var listArticle = await _context.GetArticles();

            return Ok(listArticle);
        }

        [HttpPost]
        public IActionResult addArticle(CreateArticleDto createArticleDto)
        {
            if (ModelState.IsValid)
            {
                var article = _context.InserArticle(new Models.Article()
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

        [HttpPatch]
        public async Task<IActionResult> editArticleAsync(Guid Id, PutArticleDto putArticleDto)
        {
            if (ModelState.IsValid)
            {
                var userNew = new Article()
                {
                    Title = putArticleDto.Title,
                    Content = putArticleDto.Content,
                };
                return Ok(await _context.EditArticle(Id, userNew));

            }
            else
            {
                return BadRequest(ModelState.ErrorCount);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteArticle([FromQuery] Guid id)
        {
            return Ok(await _context.DeleteArticle(id));
        }
    }
}