using EVChargingStationApi.IRepository;
using EVChargingStationApi.Models;
using EVChargingStationApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add dbcontext
builder.Services.AddDbContext<EvchargingStationContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("EVChargingStationDb")));
builder.Services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//using cors for allow api in front end (cross origin)
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//allowing only selected origin
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthorization();

app.MapControllers();

app.Run();
