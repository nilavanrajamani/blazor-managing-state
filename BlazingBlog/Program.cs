using BlazingBlog.Components;
using BlazingBlog.Models;

var builder = WebApplication.CreateBuilder(args);

var blogPosts = new List<BlogPost>
    {
        new BlogPost { Id = 1, Title = "First post", Content = "This is the first post" },
        new BlogPost { Id = 2, Title = "Second post", Content = "This is the second post" },
        new BlogPost { Id = 3, Title = "Third post", Content = "This is the third post" },
    };

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingValue(_ => blogPosts);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
