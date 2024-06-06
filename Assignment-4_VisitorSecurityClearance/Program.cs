using Assignment_4_VisitorSecurityClearance.CosmosDb;
using Assignment_4_VisitorSecurityClearance.Interfaces;
using Assignment_4_VisitorSecurityClearance.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddScoped<ICosmosDbService, CosmosDbService>();

builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<ISecurityCosmosDbService, SecurityCosmosDbService>();

builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IManagerCosmosDbService, ManagerCosmosDbService>();

builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<IOfficeCosmosDbService, OfficeCosmosDbService>();

builder.Services.AddScoped<LoginInterface, LoginService>();
builder.Services.AddScoped<LoginInterfaceCosmosDbService, LoginCosmosDbService>();

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
