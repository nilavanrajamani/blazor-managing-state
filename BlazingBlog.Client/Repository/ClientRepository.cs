using BlazingBlog.Shared;
using BlazingBlog.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazingBlog.Client.Repository
{
    public class ClientRepository : IBlogRepository
    {
        private readonly HttpClient _httpClient;

        public ClientRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BlogPost> AddPostAsync(BlogPost post)
        {
            await _httpClient.PostAsJsonAsync<BlogPost>("/api/posts", post);
            return post;
        }

        public async Task DeletePostAsync(int id)
        {
            await _httpClient.DeleteAsync($"/api/posts/{id}");             
        }

        public async Task<BlogPost> GetPostAsync(int id)
        {
           return await _httpClient.GetFromJsonAsync<BlogPost>($"/api/posts/{id}");
        }

        public async Task<List<BlogPost>> GetPostsAsync()
        {
            return await _httpClient!.GetFromJsonAsync<List<BlogPost>>("/api/posts");
        }

        public async Task<BlogPost> UpdatePostAsync(BlogPost post)
        {
            await _httpClient.PutAsJsonAsync<BlogPost>($"/api/posts/{post.Id}", post);
            return post;
        }
    }
}
