using Book_BL.DataManager;
using Book_BL.Repository;
using Book_DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<BookDBContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionBook")));
builder.Services.AddScoped<IDataRepository<Book>, BookManager>();
builder.Services.AddScoped<IDataRepository<User>, UserManager>();
builder.Services.AddScoped<IDataRepository<BookUser>, BookUserManager>();

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
