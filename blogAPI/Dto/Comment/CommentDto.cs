using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models;

namespace blogAPI.Dto.Article
{
    public class CommentDto
    {
        public Guid ID {get ; set;}
       public String Content { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ArticleId { get; set; }
    }
}