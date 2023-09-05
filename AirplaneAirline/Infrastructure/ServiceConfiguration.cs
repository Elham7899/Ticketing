using Microsoft.EntityFrameworkCore;
using Ticketing.BLL.Contract.Contract;
using Ticketing.BLL.Services;
using Ticketing.DAL.Contract.Contract;
using Ticketing.DAL.EFDBContexts;
using Ticketing.DAL.Repositories;
using Ticketing.DAL.UnitOfWorks;

namespace Ticketing.Host.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static void RegisterationService(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IInformationBLL, InformationBLL>();
            builder.Services.AddScoped<IUserBLL, UserBLL>();
            builder.Services.AddScoped<IAirlineBLL, AirlineBLL>();
            builder.Services.AddScoped<IAirplaneBLL, AirplaneBLL>();
            builder.Services.AddScoped<ICountryBLL, CountryBLL>();

            builder.Services.AddScoped<IAirlineDAL, AirlineRepository>();
            builder.Services.AddScoped<IUserDAL, UserRepository>();
            builder.Services.AddScoped<ICountryDAL, CountryRepository>();
            builder.Services.AddScoped<IAirplaneDAL, AirplaneRepository>();
            builder.Services.AddScoped<ICompanyDAL, CompanyRepository>();

            builder.Services.AddDbContext<DBContexts>(option =>
            {
                option.UseSqlServer("Password=12345;Persist Security Info=True;User ID=sa;Initial Catalog=LoginPage;Data Source=.;TrustServerCertificate=Yes");
            });
        }
    }
}
