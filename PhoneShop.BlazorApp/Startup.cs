using Blazored.LocalStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using PhoneShop.BlazorApp.Data;
using PhoneShop.BlazorApp.Helpers;
using Phoneshop.Business;
using Phoneshop.Business.Repositories;
using Phoneshop.Domain.Interfaces;
using ApiClientLibary;

namespace PhoneShop.BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ServerAuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddBlazorise(x => { })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
            services.AddBlazoredLocalStorage(x => x.JsonSerializerOptions.WriteIndented = true);
            services.AddHttpClient();
            services.AddHttpClient();

            services.AddScoped<ApiAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(provider =>
                provider.GetRequiredService<ApiAuthenticationStateProvider>());

            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=localhost,1433;Initial Catalog=Phones;User ID=sa;Password=Itvitaefase2!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddSingleton<ILoggerService, LoggerService>();

            services.AddSingleton<IPhoneClient, PhoneClient>();
            services.AddSingleton<ILoginClient, LoginClient>();
            services.AddSingleton<IRegisterClient, RegisterClient>();


            services.AddPhoneShopApiClient("https://localhost:44393");


        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

        }
    }
}
