using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazingBlog.Repository
{
    public class BlogDbContextFactory : DbContextFactory<BlogDbContext>
    {
        private readonly IServiceProvider _serviceProvider;

        public BlogDbContextFactory(IServiceProvider serviceProvider, DbContextOptions<BlogDbContext> options, IDbContextFactorySource<BlogDbContext> factorySource) : base(serviceProvider, options, factorySource)
        {
            _serviceProvider = serviceProvider;            
        }

        public override BlogDbContext CreateDbContext()
        {            
            return _serviceProvider.GetRequiredService<BlogDbContext>();
        }
    }
}
