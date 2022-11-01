using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models;

namespace blogAPI.Dto.User
{
    public class CreateArticleDto
    {
        public String Title { get; set; }
        public String Content { get; set; }
    }
}