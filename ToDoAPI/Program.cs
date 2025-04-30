using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoAPI.Data;
using ToDoAPI.Interfaces.Repository;
using ToDoAPI.Interfaces.Services;
using ToDoAPI.Sevices;
using ToDoAPI.Sevices.Auth;
using ToDoAPI.Sevices.JWT;
using ToDoAPI.Sevices.PasswordHasher;
using Serilog;



Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog();

    // Add services to the container.

    builder.Services.AddDbContext<ToDoContext>(options =>
        options.UseInMemoryDatabase("TodoDatabase"));

    builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

    builder.Services.AddScoped<IAuthRepository, AuthRepository>();
    builder.Services.AddScoped<ITaskRepository, TasksRepository>();


    builder.Services.AddScoped<IUserRepository, UserRepository>();


    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();



    //JWT 
    builder.Services.AddAuthentication(configuration =>
    {
        configuration.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        configuration.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(configuration =>
    {
        configuration.RequireHttpsMetadata = false;
        configuration.SaveToken = true;
        configuration.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey
            (
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!)
            )
        };
    });



    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
