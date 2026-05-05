using Blog.Core.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entites
{
    public enum PostStatus
    {
        [EnumMember(Value = "Published")]
        Published,
        [EnumMember(Value = "Draft")]
        Draft,
        [EnumMember(Value = "Archived")]
        Archived
    }

    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
        public PostStatus PostStatus { get; set;}
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string AuthorId { get; set; }
        public AppUser Author { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
