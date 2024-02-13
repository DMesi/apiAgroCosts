using StorageServiceLibrary.Model;         //**********************
using Serilog;                                //**********************

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddRepository();           //**********************

Log.Logger = new LoggerConfiguration()      //**********************
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
                                        //**********************






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


