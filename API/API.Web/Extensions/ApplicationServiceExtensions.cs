using API.Core.Interfaces;
using API.DataAccess.Data;
using API.DataAccess.Repositories;
using API.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Web.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<IBorrowerRepository, BorrowerRepository>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBorrowerService, BorrowerService>();
            services.AddTransient<ILoanService, LoanService>();

            return services;
        }
    }
}
