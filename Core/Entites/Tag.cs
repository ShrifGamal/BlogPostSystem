using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entites
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BlogPost> Posts { get; set; }
    }
}
