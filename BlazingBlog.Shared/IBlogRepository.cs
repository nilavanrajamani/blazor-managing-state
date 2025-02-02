using BlazingBlog.Shared.Models;

namespace BlazingBlog.Shared
{
    public interface IBlogRepository
    {
        Task<List<BlogPost>> GetPostsAsync();
        Task<BlogPost> GetPostAsync(int id);
        Task<BlogPost> AddPostAsync(BlogPost post);
        Task<BlogPost> UpdatePostAsync(BlogPost post);
        Task DeletePostAsync(int id);
    }
}
