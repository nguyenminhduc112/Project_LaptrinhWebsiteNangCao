using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models;

namespace blogAPI.Dto.Article
{
    public class ArticleDto
    {
        public Guid ID {get ; set;}
        public String Title { get; set; }
        public String Content { get; set; }
        public int viewCount { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ArticleTag> ArticleTags { get; set; } // 1 article có nhiều tag
        public ICollection<Comment> Comments { get; set; } // 1 article có nhiều comnent
        public ICollection<ArticleLiker> ArticleLikers { get; set; } // 1 article có nhiều like những chỉ 1 user 1 like
    }
}