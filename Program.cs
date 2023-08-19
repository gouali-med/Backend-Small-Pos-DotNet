using GestionCommercialeServices.Models;
using GestionCommercialeServices.Models.Class;
using GestionCommercialeServices.Models.Repositories;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var connectionString = builder.Configuration.GetConnectionString("SqlCon") ?? throw new InvalidOperationException("Connection string 'DBCONTEXTContextConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IDbContextApp<Category>, CategoryRepository>();
builder.Services.AddScoped<IDbContextApp<Client>, ClientRepository>();
builder.Services.AddScoped<IDbContextApp<Company>, CompanyRepository>();
builder.Services.AddScoped<IDbContextApp<PaymentClient>, PaymentClientRepository>();
builder.Services.AddScoped<IDbContextApp<Taxe>, TaxeRepository>();
builder.Services.AddScoped<IDbContextApp<TypePayment>, TypePaymentRepository>();
builder.Services.AddScoped<IDbContextApp<UniteOfSale>, UniteVenteRepository>();
builder.Services.AddScoped<IDbContextApp<Sale>, VenteRepository>();
builder.Services.AddScoped<IDbContextApp<DetailsSale>, DetailsSaleRepository>();
builder.Services.AddScoped<IDbContextApp<Product>, ProductRepository>();

builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


app.UseCors("MyPolicy");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider=new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath,"wwwroot/Images")),
    RequestPath= "/wwwroot/Images"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
