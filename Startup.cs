
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApiProj.Extensions;
using WebApiProj.IServices;
using WebApiProj.Jwt;
using WebApiProj.Models;
using WebApiProj.Repositories;
using WebApiProj.Services;

namespace WebApiProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkNpgsql().AddDbContext<BooksContext>(opt=> opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))) ;
            services.AddEntityFrameworkNpgsql().AddDbContext<CommentsContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddEntityFrameworkNpgsql().AddDbContext<GroupsContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddHttpClient();

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
     .AddEntityFrameworkStores<ApplicationContext>()
     .AddDefaultTokenProviders();



            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });


            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();



            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IGroupService, GroupService>();


            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddAuth(jwtSettings);







        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuth();


            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
