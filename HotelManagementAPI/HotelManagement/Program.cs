using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Text;
using DataAccessLayer;
using BusinessLogicLayer;
using CommonDataLayer;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Dependency Injection
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));

builder.Services.AddScoped<IBlogDL, BlogDL>();
builder.Services.AddScoped<IBlogBL, BlogBL>();

// Add services to the container.
builder.Services.AddControllers();
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("SqlServerConnection");

// Validate entity
builder.Services.AddControllers().ConfigureApiBehaviorOptions(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddCors(option =>
{
    option.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
});

// Config Authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysceret.....")),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

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

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

// Check database connection
var connectionString = DatabaseContext.ConnectionString;
using (var connection = new SqlConnection(connectionString))
{
    try
    {
        connection.Open();
        app.Logger.LogInformation("Database connection successful.");
    }
    catch (Exception ex)
    {
        app.Logger.LogError($"Database connection failed: {ex.Message}");
    }
}

app.MapControllers();

app.Run();
