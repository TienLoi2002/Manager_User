using Manager_User_API;
using Manager_User_API.IRepositories;
using Manager_User_API.IServices;
using Manager_User_API.Repositories;
using Manager_User_API.Service;
using Manager_User_Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AutoMapperProfile));


            var jwtSettings = Configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = jwtSettings["Issuer"],
                                    ValidAudience = jwtSettings["Audience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(key)
                                };
                            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("add", policy => policy.RequireClaim("add"));
                options.AddPolicy("update", policy => policy.RequireClaim("update"));
                options.AddPolicy("delete", policy => policy.RequireClaim("delete"));
                options.AddPolicy("get", policy => policy.RequireClaim("get"));
            });



            // Register repositories and services
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<TokenHelper>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserIdClaimTypeAndCliamValueRepository, UserIdClaimTypeAndCliamValueRepository>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IClaimService, ClaimService>();

            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormService, FormService>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped<IUserClaimRepository, UserClaimRepository>();
            services.AddScoped<IUserClaimService, UserClaimService>();

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
