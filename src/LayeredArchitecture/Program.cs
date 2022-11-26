using LayeredArchitecture.Repositories.interfaces;
using LayeredArchitecture.Repositories;
using LayeredArchitecture.Services.interfaces;
using LayeredArchitecture.Services;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<MRPSystemDbContext>(options =>
                options.UseInMemoryDatabase("MRPSystemDb"));
builder.Services.AddScoped<IPartNumberRepository, PartNumberRepository>();
builder.Services.AddScoped<IPartNumberService, PartNumberService>();
builder.Services.AddScoped<IPurchaseRequestRepository, PurchaseRequestRepository>();
builder.Services.AddScoped<IPurchaseRequestService, PurchaseRequestService>();
builder.Services.AddScoped<IPurchaseRequestItemRepository, PurchaseRequestItemRepository>();
builder.Services.AddScoped<IPurchaseRequestItemService, PurchaseRequestItemService>();
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
