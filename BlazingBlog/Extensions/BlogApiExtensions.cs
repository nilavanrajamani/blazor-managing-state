using BlazingBlog.Shared;
using BlazingBlog.Shared.Models;
using BlazingBlog.Shared.Repository;

namespace BlazingBlog.Extensions
{
    public static class BlogApiExtensions
    {
        public static WebApplication UseBlogApi(this WebApplication app)
        {
            app.MapGet("/api/posts", async (IBlogRepository blogRepository) => await blogRepository.GetPostsAsync());
            app.MapGet("/api/posts/{id}", async (IBlogRepository blogRepository, int id) => await blogRepository.GetPostAsync(id));
            app.MapPost("/api/posts", async (IBlogRepository blogRepository, BlogPost blog) => await blogRepository.AddPostAsync(blog));
            app.MapPut("/api/posts/{id}", async (IBlogRepository blogRepository, int id, BlogPost blog) => { return await blogRepository.UpdatePostAsync(blog); });
            app.MapDelete("/api/posts/{id}", async (IBlogRepository blogRepository, int id) => await blogRepository.DeletePostAsync(id));
            return app;
        }
    }
}
