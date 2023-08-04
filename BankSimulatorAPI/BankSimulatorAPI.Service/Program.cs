using BankSimulatorAPI.Data.DBContext;
using BankSimulatorAPI.Data.Repository.AccountRepository;
using BankSimulatorAPI.Data.Repository.CustomerRepository;
using BankSimulatorAPI.Data.Repository.TransactionRepository;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

////dbContext
var dbType = builder.Configuration.GetConnectionString("DbType");
if (dbType == "MsSql")
{
    builder.Services.AddDbContext<SimDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));
}

//Repository register
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
