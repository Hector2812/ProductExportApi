using ProductExportApi.Repositories;
using ProductExportApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ExportService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();