using BlazingBlog.Repository;
using BlazingBlog.Shared.Models;
using BlazingBlog.State;
using Microsoft.EntityFrameworkCore;

namespace BlazingBlog.Shared.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IDbContextFactory<BlogDbContext> _blogDbContextFactory;
        private readonly BlogStateService _blogStateService;

        public BlogRepository(IDbContextFactory<BlogDbContext> blogDbContextFactory, 
            BlogStateService blogStateService)
        {
            _blogDbContextFactory = blogDbContextFactory;
            _blogStateService = blogStateService;
        }        

        public async Task<List<BlogPost>> GetPostsAsync()
        {
            using var _dbContext = _blogDbContextFactory.CreateDbContext();
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<BlogPost> GetPostAsync(int id)
        {
            using var _dbContext = _blogDbContextFactory.CreateDbContext();
            return await _dbContext!.Posts!.FirstOrDefaultAsync(p => p.Id == id);            
        }

        public async Task<BlogPost> AddPostAsync(BlogPost post)
        {
            using var _dbContext = _blogDbContextFactory.CreateDbContext();
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            _blogStateService.NotifyStateChanged();
            return post;
        }

        public async Task<BlogPost> UpdatePostAsync(BlogPost post)
        {
            using var _dbContext = _blogDbContextFactory.CreateDbContext();
            var existingPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
            }
            _dbContext.Entry(existingPost).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            _blogStateService.NotifyStateChanged();
            return existingPost;
        }

        public async Task DeletePostAsync(int id)
        {
            using var _dbContext = _blogDbContextFactory.CreateDbContext();
            var post = await _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
            }
        }        
    }
}
