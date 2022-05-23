using d1.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using d1.Repos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace d1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<context>(optios => {
                optios.UseSqlServer("Data Source=.;Initial Catalog=webApiLabs;Integrated Security=True");
            });
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "d1", Version = "v1" });
            });
            services.AddCors(corsOptions => {
                corsOptions.AddPolicy("policy", corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<context>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;//check expire
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["jwt:issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["jwt:audiance"],
                    IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "d1 v1"));
            }



            app.UseCors("policy");
            //serve images
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider=new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"images")
                    ),
                RequestPath="/images"
            });
            app.UseRouting();
            app.UseAuthentication(); ;
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
