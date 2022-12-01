using Microsoft.EntityFrameworkCore;
using txs_hub_api.Data;
using txs_hub_api.Services;
using txs_hub_api.Repositories;
using txs_hub_api.Helpers.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();


// Add database context

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add repositories, services, seeders and utils


builder.Services.AddRepositories();
builder.Services.AddServices();


/*builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
*/


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
