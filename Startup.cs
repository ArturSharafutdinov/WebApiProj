using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiProj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using WebApiProj.Repositories;
using WebApiProj.Services;
using WebApiProj.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            // services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddHttpClient();
            /*
                services.AddIdentity<IdentityUser, IdentityRole>(options=>
               {
                   options.Password.RequireDigit = true;
                   options.Password.RequireLowercase = true;
                   options.Password.RequiredLength = 5;
               }
               ).AddEntityFrameworkStores<ApplicationContext>()
               .AddDefaultTokenProviders();

               services.AddAuthentication(auth =>
               {
                   auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }
               ).AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       RequireExpirationTime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("The key used in encryption")),
                       ValidateIssuerSigningKey = true,


                   };
               });
             */


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

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
