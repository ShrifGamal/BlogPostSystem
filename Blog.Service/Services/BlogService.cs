using AutoMapper;
using Blog.Core;
using Blog.Core.Dtos;
using Blog.Core.Entites;
using Blog.Core.ServicesContract;
using Blog.Core.Specifications.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var Category = await _unitOfWork.Repository<Category>().GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(Category);
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllPostsAsync(PostSpecParams specParams)
        {
            var spec = new BlogPostSpecifications(specParams);
            var AllPosts = await _unitOfWork.Repository<BlogPost>().GetAllWithSpecAsync(spec);
            var MappedPosts = _mapper.Map<IEnumerable<BlogPostDto>>(AllPosts);
            return MappedPosts;
        }

        public async Task<BlogPostDto> GetPostByIdAsync(int id)
        {
            var spec = new BlogPostSpecifications(id);
            var Post = await _unitOfWork.Repository<BlogPost>().GetByIdAWithSpecAsync(spec);
            var MappedPost = _mapper.Map<BlogPostDto>(Post);
            return MappedPost;
        }
    }
}
