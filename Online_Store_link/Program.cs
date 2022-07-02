using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Online_Store_link.Data.Context;
using Online_Store_link.Data.Repositories;
using Online_Store_link.Data.UnitOfWork;

#region Saif - Enable CORS - create string
string MyAllowAll = "_myAllowAll";
#endregion

var builder = WebApplication.CreateBuilder(args);

#region Saif - Enable CORS - AddCors
builder.Services.AddCors(options => 
{
    options.AddPolicy(name: MyAllowAll, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
#endregion

// Add services to the container.

#region Saif - Register Connection String
// get connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("OnlineStore");
// add connection string to OnlineStoreContext with SqlServer Provider
builder.Services.AddDbContext<OnlineStoreContext>(options => options.UseSqlServer(connectionString));
#endregion

#region Saif - Lifetime and registration options for Dependency injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region Saif - Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region - Saif - Avoid the MultiPartBodyLength error
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Saif - Enable CORS - UseCors
app.UseCors(MyAllowAll);
#endregion

#region Saif - Serving Static Files
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
