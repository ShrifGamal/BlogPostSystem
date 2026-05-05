using Blog.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Specifications.Post
{
    public class BlogPostSpecifications : BaseSpecifications<BlogPost>
    {

        public BlogPostSpecifications(int id):base(P => P.Id == id) 
        {
            ApplyIncludes();
        }

        public BlogPostSpecifications(PostSpecParams specParams):base(P =>
        (string.IsNullOrEmpty(specParams.Search)||P.Title.ToLower().Contains(specParams.Search))
        &&
        (!specParams.CategoryId.HasValue|| specParams.CategoryId == P.CategoryId)
        )
        {
            ApplyIncludes();
        }

        private void ApplyIncludes()
        {
            Includes.Add(P => P.Author);
            Includes.Add(P => P.Category);
            Includes.Add(P => P.Tags);
            Includes.Add(P => P.Comments);


        }
    }
}
