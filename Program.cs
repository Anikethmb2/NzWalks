using Microsoft.EntityFrameworkCore;
using NzWalks.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
//Adding Database DI
// builder.Services.AddDbContext<NzWalkDbContext>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalkConnectionString")));

builder.Services.AddDbContext<NzWalkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalkConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();


app.MapControllers();
app.Run();

