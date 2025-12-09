using ecommerce.Persistence.DependencyResolver;
using ecommerce.Application.DependencyResolver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Persistence Services
builder.Services.AddDbContextService();
builder.Services.AddRepositoryServices();

// Application Services
builder.Services.AddAutoMapperService();
builder.Services.AddMediatRService();

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
