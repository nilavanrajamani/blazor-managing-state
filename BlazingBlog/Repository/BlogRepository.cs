using BlazingBlog.Shared.Models;

namespace BlazingBlog.Shared.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private List<BlogPost> _posts = new List<BlogPost>
            {
                new BlogPost { Id = 1, Title = "First post", Content = "This is the first post" },
                new BlogPost { Id = 2, Title = "Second post", Content = "This is the second post" },
                new BlogPost { Id = 3, Title = "Third post", Content = "This is the third post" },
            };

        public event Action OnStateChanged;

        public Task<List<BlogPost>> GetPostsAsync()
        {
            return Task.FromResult(_posts);
        }

        public Task<BlogPost> GetPostAsync(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(post);
        }

        public Task<BlogPost> AddPostAsync(BlogPost post)
        {
            post.Id = _posts.Count > 0 ? _posts.Max(p => p.Id) + 1 : 1;
            _posts.Add(post);            
            return Task.FromResult(post);
        }

        public Task<BlogPost> UpdatePostAsync(BlogPost post)
        {
            var existingPost = _posts.FirstOrDefault(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
            }

            OnStateChanged.Invoke();
            return Task.FromResult(existingPost);
        }

        public Task DeletePostAsync(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _posts.Remove(post);
            }
            return Task.CompletedTask;
        }        
    }
}
