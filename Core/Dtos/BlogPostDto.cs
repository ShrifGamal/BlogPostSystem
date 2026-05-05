using Blog.Core.Entites;
using Blog.Core.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Dtos
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string PostStatus { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<string> TagsName { get; set; }
        public List<string> CommentContent { get; set; }
    }
}
