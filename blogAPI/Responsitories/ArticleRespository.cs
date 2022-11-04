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
    public class ArticleRespository
    {
        private readonly AppDbContext _context;
        public ArticleRespository(AppDbContext context)
        {
            _context = context;
        }
        public ArticleDto InserArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();

            var result = new ArticleDto()
            {
                ID = article.Id,
                Title = article.Title,
                Content = article.Content,
                AuthorId = article.AuthorId
            };
            return result;
        }
        public async Task<List<ArticleDto>> GetArticles()
        {
            return await _context.Articles.AsNoTracking().Select(article => new ArticleDto()
            {
                ID = article.Id,
                Title = article.Title,
                Content = article.Content,
                AuthorId = article.AuthorId,
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
        public async Task<bool> DeleteArticle(Guid Id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(article => article.Id == Id);
            if (article == null)
            {
                return false;
            };
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ArticleDto> EditArticle(Guid Id, Article article)
        {
            var articleExist = await _context.Articles.FirstOrDefaultAsync(article => article.Id == Id);
            if (articleExist == null)
            {
                return null;
            };
            articleExist.Title = article.Title;
            articleExist.Content = article.Content;
            await _context.SaveChangesAsync();
            return new ArticleDto()
            {
                Title = article.Title,
                Content = article.Content,
        };
    }
}
}