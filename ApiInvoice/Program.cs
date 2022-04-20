using ApiInvoice.Models;
using ApiInvoice.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<InvoiceDatabaseSettings>(
    builder.Configuration.GetSection(nameof(InvoiceDatabaseSettings)));

builder.Services.AddSingleton<IinvoiceDatabaseSettings>(sp =>
sp.GetRequiredService<IOptions<InvoiceDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
 new MongoClient(builder.Configuration.GetValue<string>("InvoiceDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IinvoiceService, InvoiceService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(); //configurar cors desde cualquier dominio
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); //configurar cors desde cualquier dominio

app.UseAuthorization();

app.MapControllers();

app.Run();
