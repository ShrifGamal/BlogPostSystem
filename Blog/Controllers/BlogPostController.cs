using Blog.Core.Dtos;
using Blog.Core.ServicesContract;
using Blog.Core.Specifications.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogPostController(IBlogService blogService )
        {
            _blogService = blogService;
        }
        [HttpGet("GetAllPosts")]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetAllPosts([FromQuery]PostSpecParams specParams)
        {
            var posts = await _blogService.GetAllPostsAsync(specParams);
            return Ok(posts);

        }

        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategory()
        {
            var category = await _blogService.GetAllCategoriesAsync();
            return Ok(category);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<BlogPostDto>>GetById(int? id)
        {
            if (id == null) return BadRequest();
            var post = await _blogService.GetPostByIdAsync(id.Value);
            if(post == null) return NotFound();
            return Ok(post);

        }
    }
}
