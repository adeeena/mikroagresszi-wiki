using Microsoft.EntityFrameworkCore;
using Mikroagresszi.Logic.BusinessLogic;
using Mikroagresszi.Logic.BusinessLogic.Interfaces;
using MikroagressziWiki.Domain.Models;
using MikroagressziWiki.Logic.BusinessLogic;
using MikroagressziWiki.Logic.BusinessLogic.Interfaces;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryLogic, CategoryLogic>();
builder.Services.AddScoped<IEntryLogic, EntryLogic>();


string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MikroagressziContext>(options =>
   options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

WebApplication? app = builder.Build();

app.UseCors("CorsPolicy");

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


