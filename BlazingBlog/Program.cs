using BlazingBlog.Components;
using BlazingBlog.Extensions;
using BlazingBlog.Repository;
using BlazingBlog.Shared;
using BlazingBlog.Shared.Repository;
using BlazingBlog.State;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<IBlogRepository, BlogRepository>();
builder.Services.AddSingleton<BlogStateService>();
builder.Services.AddDbContextFactory<BlogDbContext>(options => options.UseSqlite("Data Source=blazingblog.db"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseBlogApi();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazingBlog.Client._Imports).Assembly);

app.Run();
