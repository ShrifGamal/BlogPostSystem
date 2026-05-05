using Blog.Core.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entites
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? PostId { get; set; }
        public BlogPost Post { get; set; }
        public string? AuthorId { get; set; }
        public AppUser Author { get; set; }

    }
}
