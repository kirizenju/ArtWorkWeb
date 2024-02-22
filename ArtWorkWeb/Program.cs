using ArtWorkWeb.Extensions;
using BussinessTier.Constants;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Text.Json.Serialization;
using ArtWorkWeb.Service.Interfaces;
using ArtWorkWeb.Service.Implement;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.ClearProviders();
        // Add services to the container.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: CorsConstant.PolicyName,
                policy =>
                {
                    policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
        });
        builder.Services.AddControllers().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            x.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
        });
        builder.Services.AddDatabase(builder);
        builder.Services.AddUnitOfWork();
        builder.Services.AddJwtValidation();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddHttpContextAccessor();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddConfigSwagger();
        builder.Services.AddScoped<IUserService, UserService>();

        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
                    
        app.Run();
    }
}