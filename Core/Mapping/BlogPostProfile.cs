using AutoMapper;
using Blog.Core.Dtos;
using Blog.Core.Entites;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Mapping
{
    public class BlogPostProfile : Profile
    {
        public BlogPostProfile()
        {
            CreateMap<BlogPost, BlogPostDto>()
                   .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.DesplayName))
                   .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                   .ForMember(dest => dest.TagsName, opt => opt.MapFrom(src => src.Tags.Select(t => t.Name)))
                   .ForMember(dest => dest.CommentContent, opt => opt.MapFrom(src => src.Comments.Select(c => c.Content)))
                   .ForMember(dest => dest.PostStatus, opt => opt.MapFrom(src => src.PostStatus.ToString()));

            CreateMap<Category, CategoryDto>();
        }
    }
}
