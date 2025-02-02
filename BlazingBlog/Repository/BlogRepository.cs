using BlazingBlog.Repository;
using BlazingBlog.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingBlog.Shared.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _dbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _dbContext = blogDbContext;
        }

        public event Action OnStateChanged;

        public async Task<List<BlogPost>> GetPostsAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<BlogPost> GetPostAsync(int id)
        {
            return await _dbContext!.Posts!.FirstOrDefaultAsync(p => p.Id == id);            
        }

        public async Task<BlogPost> AddPostAsync(BlogPost post)
        {            
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            OnStateChanged.Invoke();
            return post;
        }

        public async Task<BlogPost> UpdatePostAsync(BlogPost post)
        {
            var existingPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
            }
            _dbContext.Entry(existingPost).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            OnStateChanged.Invoke();
            return existingPost;
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
            }
        }        
    }
}
