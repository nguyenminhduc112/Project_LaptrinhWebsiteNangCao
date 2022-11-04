using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models;

namespace blogAPI.Dto.User
{
    public class CreateCommentDto
    {
        public String Content { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ArticleId { get; set; }
    }
}