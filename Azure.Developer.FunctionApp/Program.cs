using CDW.Developer.Service.Api;
using CDW.Developer.Service.Common;
using CDW.Developer.Service.DbContext;
using CDW.Developer.Service.Repository;
using CDW.Developer.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
               .ConfigureFunctionsWebApplication()
               .ConfigureServices((context, services) =>
               {
                   var _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                                            .UseInMemoryDatabase(Constants.InMemoryDatabaseName)
                                            .Options;

                   services.AddSingleton(new AppDbContext(_contextOptions));

                   services.AddScoped<IBankHolidayService, BankHolidayService>();
                   services.AddScoped<IRequestRepository, RequestRepository>();
                   services.AddScoped<IApiService, ApiService>();
                   services.AddScoped<HttpClient>();
               })
               .Build();

host.Run();