using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Data;
using blogAPI.Dto.Article;
using blogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace blogAPI.Responsitories
{
    public class CommentRespository
    {
        private readonly AppDbContext _context;
        public CommentRespository(AppDbContext context)
        {
            _context = context;
        }
        public CommentDto InserComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();

            var result = new CommentDto()
            {
                ID = comment.Id,
                ArticleId = comment.ArticleId,
                Content = comment.Content,
                AuthorId = comment.AuthorId
            };
            return result;
        }
        public async Task<List<CommentDto>> GetComments()
        {
            return await _context.Comments.AsNoTracking().Select(comment => new CommentDto()
            {
                ID = comment.Id,
                ArticleId = comment.ArticleId,
                Content = comment.Content,
                AuthorId = comment.AuthorId
            }).ToListAsync();
        }
        // public async Task<ArticleDto> GetUser(Guid Id)
        // {
        //     var article = await _context.Articles.FirstOrDefaultAsync(article => article.Id == Id);
        //     if (article == null)
        //     {
        //         return null;
        //     };
        //     return article;
        // }
        public async Task<bool> DeleteComment(Guid Id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == Id);
            if (comment == null)
            {
                return false;
            };
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CommentDto> EditComment(Guid Id, Comment comment)
        {
            var commentExist = await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == Id);
            if (commentExist == null)
            {
                return null;
            };
            commentExist.Content = comment.Content;
            await _context.SaveChangesAsync();
            return new CommentDto()
            {
                Content = comment.Content,
        };
    }
}
}