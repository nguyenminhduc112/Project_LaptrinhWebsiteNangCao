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
    public class CommentController : ControllerBase
    {
        private readonly CommentRespository _context;
        public CommentController(CommentRespository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListComments()
        {

            var listComment = await _context.GetComments();

            return Ok(listComment);
        }

        [HttpPost]
        public IActionResult addComment(CreateCommentDto createCommentDto)
        {
            if (ModelState.IsValid)
            {
                var comment = _context.InserComment(new Models.Comment()
                {
                    ArticleId = createCommentDto.ArticleId,
                    Content = createCommentDto.Content,
                    AuthorId = createCommentDto.AuthorId,
                });
                return Ok(comment);
            }else{
                return BadRequest(ModelState.ErrorCount);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> editCommentAsync(Guid Id, PutCommentDto putCommentDto)
        {
            if (ModelState.IsValid)
            {
                var commentNew = new Comment()
                {
                    Content = putCommentDto.Content,
                };
                return Ok(await _context.EditComment(Id, commentNew));

            }
            else
            {
                return BadRequest(ModelState.ErrorCount);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromQuery] Guid id)
        {
            return Ok(await _context.DeleteComment(id));
        }
    }
}