using AlexPortTracking.Data;
using AlexPortTracking.Repos.Car;
using AlexPortTracking.Repos.Reader;
using AlexPortTracking.Repos.ReaderType;
using AlexPortTracking.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AlexPortTrackingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
    );


// Add services to the container.
builder.Services.AddTransient<IReaderTypeRepo, ReaderTypeRepo>();
builder.Services.AddTransient<ICarRepo, CarRepo>();
builder.Services.AddTransient<IReaderRepo, ReaderRepo>();
builder.Services.AddHostedService<StartReader>();

builder.Services.AddControllers().AddJsonOptions(opt =>
                                       opt.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
