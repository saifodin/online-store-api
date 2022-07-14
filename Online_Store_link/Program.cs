using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Online_Store_link.Data.Context;
using Online_Store_link.Data.Repositories;
using Online_Store_link.Data.UnitOfWork;
using Online_Store_link.Models.DBModels;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Saif - Enable CORS - AddCors
string MyAllowAll = "_myAllowAll";
builder.Services.AddCors(options => 
{
    options.AddPolicy(name: MyAllowAll, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
#endregion

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
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region Saif - Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Saif - Avoid the MultiPartBodyLength error
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
#endregion

#region Saif - ASP Identity Package
builder.Services.AddIdentity<Customer, IdentityRole>(options => // who's user
{
    //password
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    //email
    options.User.RequireUniqueEmail = true;
    //failed
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

}).AddEntityFrameworkStores<OnlineStoreContext>(); // who's context
#endregion

#region Saif - Add Middleware to Authenticate
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "myAuth";
    options.DefaultChallengeScheme = "myAuth";
})
    .AddJwtBearer("myAuth", option => //using package (microsoft.aspnetcore.authentication.jwtbearer)
    {
        string secretKeyString = builder.Configuration.GetValue<string>("SecretKey");
        byte[] secretKeyBytes = Encoding.ASCII.GetBytes(secretKeyString);
        SymmetricSecurityKey secretKey = new(secretKeyBytes);
        option.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = secretKey,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
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

#region Saif - Use Authentication
app.UseAuthentication();
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
