using firstAPI_2023_04_19.Filter;
using firstAPI_2023_04_19.IService;
using firstAPI_2023_04_19.Models;
using firstAPI_2023_04_19.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<SampleExceptionFilter>();
});
//builder.Services.AddScoped<SampleExceptionFilter>();
builder.Services.AddScoped<IQueryInfoMessages, InfoMessagesService>();
builder.Services.AddScoped<IQueryStaff, StaffService>();
builder.Services.AddDbContext<RestfulApiTestContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Restful_Api_Test")));

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

app.Run();
