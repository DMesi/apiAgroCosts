using StorageServiceLibrary.Model;         //**********************
using Serilog;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Swashbuckle.AspNetCore.SwaggerUI;
using StorageServiceLibrary;
using Microsoft.OpenApi.Models;                                //**********************

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Agro Costs - API", Version = "v1" });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
//**********************  DependencyInjection.cs
builder.Services.AddRepository();


builder.Services.AddAuthentication();

//ServiceExtensions.cs
builder.Services.ConfigureIdentity();

builder.Services.AddCors(o => {

    o.AddPolicy("EnableCORS", builder =>

    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

});



//builder.Services.ConfigureJWT(Configuration);


//********************** Loger
Log.Logger = new LoggerConfiguration()      
            .WriteTo.File(
               path: "Content/Log/logs-.txt",
outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]{Message:lj}{NewLine}{Exception}",
               rollingInterval: RollingInterval.Day,
               restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
            ).CreateLogger();
try
{
    Log.Information("App start");
  
}
catch (Exception ex)
{
    Log.Fatal(ex, "Error");
}
finally
{
    Log.CloseAndFlush();
}

//********************** EndLoger Loger





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agro Costs");
        c.DocumentTitle = "Agro Costs";
        c.DocExpansion(DocExpansion.List);
    });
}

app.UseHttpsRedirection();


// must be this order
app.UseAuthentication(); 
app.UseAuthorization();
//

app.UseCors("EnableCORS");

app.MapControllers();

app.Run();



