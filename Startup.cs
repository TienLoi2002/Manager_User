using Manager_User_API.DTO;
using Manager_User_API.Helper;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using Manager_User_API.Model;
using Manager_User_API.Repositories;
using Manager_User_API.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Manager_User
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


            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 104857600; // Giới hạn kích thước file upload (100MB)
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AutoMapperProfile));



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("get", policy => policy.RequireClaim("get"));
                options.AddPolicy("add", policy => policy.RequireClaim("add"));
                options.AddPolicy("update", policy => policy.RequireClaim("update"));
                options.AddPolicy("delete", policy => policy.RequireClaim("delete"));
               
            });

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            

            // Register repositories and services
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<TokenHelper>();

            services.AddSingleton<CloudinaryService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IImageUploadService, ImageUploadService>();
            services.AddScoped<ISalaryService, SalaryService>();

            services.AddScoped<IUserIdClaimTypeAndCliamValueRepository, UserIdClaimTypeAndCliamValueRepository>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IClaimService, ClaimService>();

            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormService, FormService>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();

           /* services.AddScoped<IUserClaimRepository, UserClaimRepository>();
            services.AddScoped<IUserClaimService, UserClaimService>();*/

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleService, UserRoleService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseClaimsAuthorizationMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
