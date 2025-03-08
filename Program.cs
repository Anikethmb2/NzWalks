using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NzWalks.Data;
using NzWalks.Mappers;
using NzWalks.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
//Adding Database DI
// builder.Services.AddDbContext<NzWalkDbContext>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalkConnectionString")));

//DI of repository
builder.Services.AddScoped<IRegionRepository,SqlRegionRepository>();
builder.Services.AddScoped<IWalkRepository,SqlWalkRepository>();

//Adding Database DI
builder.Services.AddDbContext<NzWalkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalkConnectionString")));

builder.Services.AddDbContext<NzWalksAuthDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalksAuthConnectionString")));
//Add Auto Mapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Token service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options=>options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,    
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

