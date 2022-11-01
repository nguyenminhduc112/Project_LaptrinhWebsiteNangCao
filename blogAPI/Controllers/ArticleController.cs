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
        private readonly ArticleRespository _context;
        public ArticleController(ArticleRespository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListArticle()
        {

            var listArticle = await _context.GetArticle();

            return Ok(listArticle);
        }

        [HttpPost]
        public IActionResult addArticle(CreateArticleDto createArticleDto)
        {
            if (ModelState.IsValid)
            {
                var user = _context.InserArticle(new Models.Article()
                {
                    Title = createArticleDto.Title,
                    Content = createArticleDto.Content,
                    viewCount = createArticleDto.viewCount,
                    AuthorID = createArticleDto.AuthorID,
                    Category = createArticleDto.Category,
                });
                return Ok(Article);
            }else{
                return BadRequest(ModelState.ErrorCount);
            }
        }
    }
}