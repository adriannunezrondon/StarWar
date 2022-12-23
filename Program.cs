

using PruebaTecnica.Controllers;
using PruebaTecnica.Inject;
using PruebaTecnica.Logger;
using PruebaTecnica.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});



// Add services to the container.
//builder.Services.AddControllersWithViews();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjection(builder.Configuration);


//Log4net
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();


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
