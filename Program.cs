using Microsoft.EntityFrameworkCore;
using TaskManagementService.Models;
namespace TaskManagementService.Data

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", 
    new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "Task Management Service API", 
        Version = "v1", 
        Description = "Created a microservice for managing tasks with full CRUD operations.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Archi Patel",
            Email = "apatel3472@conestogac.on.ca"
        }
    }
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Management Service API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();