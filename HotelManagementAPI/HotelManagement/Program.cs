using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Text;
using DataAccessLayer;
using BusinessLogicLayer;
using CommonDataLayer;
using BusinessLogicLayer.BookingBL;
using BusinessLogicLayer.CouponBL;
using BusinessLogicLayer.CouponRoomBL;
using BusinessLogicLayer.UserBL;
using DataAccessLayer.BookingDL;
using DataAccessLayer.CouponDL;
using DataAccessLayer.CouponRoomDL;
using DataAccessLayer.RoomDL;
using DataAccessLayer.UserDL;
using BusinessLogicLayer.ServiceBL;
using BusinessLogicLayer.PaymentBL;
using BusinessLogicLayer.RoomBL;
using BusinessLogicLayer.ReviewBL;
using DataAccessLayer.PaymentDL;
using DataAccessLayer.ReviewDL;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Dependency Injection
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));

// Data Access Layer (DAL) - Data Layer
builder.Services.AddScoped<IBlogDL, BlogDL>();
builder.Services.AddScoped<IBookingDL, BookingDL>();
builder.Services.AddScoped<ICouponDL, CouponDL>();
builder.Services.AddScoped<ICouponRoomDL, CouponRoomDL>();
builder.Services.AddScoped<IServiceBookingDL, ServiceBookingDL>();
builder.Services.AddScoped<IPaymentDL, PaymentDL>();
builder.Services.AddScoped<IReviewDL, ReivewDL>();
builder.Services.AddScoped<IRoomDL, RoomDL>();
builder.Services.AddScoped<IServiceDL, ServiceDL>();
builder.Services.AddScoped<IUserDL, UserDL>();

// Business Logic Layer (BLL) - Business Layer
builder.Services.AddScoped<IBlogBL, BlogBL>();
builder.Services.AddScoped<IBookingBL, BookingBL>();
builder.Services.AddScoped<ICouponBL, SerivceBL>();
builder.Services.AddScoped<ICouponRoomBL, CouponRoomBL>();
builder.Services.AddScoped<IServiceBookingBL, ServiceBookingBL>();
builder.Services.AddScoped<IPaymentBL, PaymentBL>();
builder.Services.AddScoped<IReviewBL, ReviewBL>();
builder.Services.AddScoped<IRoomBL, RoomBL>();
builder.Services.AddScoped<IServiceBL, ServiceBL>();
builder.Services.AddScoped<IUserBL, UserBL>();

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
