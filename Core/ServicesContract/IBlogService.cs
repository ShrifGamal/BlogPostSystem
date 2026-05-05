using Blog.Core.Dtos;
using Blog.Core.Specifications.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.ServicesContract
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogPostDto>>GetAllPostsAsync(PostSpecParams specParams);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<BlogPostDto> GetPostByIdAsync(int id);

    }
}
