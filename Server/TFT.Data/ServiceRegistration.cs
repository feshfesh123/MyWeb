using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TFTB.Data.Context;
using TFTB.Data.Repository;

namespace TFTB.Data
{
    public static class ServiceRegistration
    {
        static string CONNECTION_STRING = "Server=tcp:tftb.database.windows.net,1433;Initial Catalog=TFTB;Persist Security Info=False;User ID=tftb;Password=@dmin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static void AddResourceData(this IServiceCollection services)
        {
            services.AddDbContext<TFTDbContext>(
                options => options.UseSqlServer(CONNECTION_STRING));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
        }
    }
}
