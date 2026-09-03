using Microsoft.EntityFrameworkCore;
using USDT_PaymentSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// تسجيل TronService
builder.Services.AddHttpClient<TronService>();

// إعداد قاعدة البيانات SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 1. تفعيل عرض ملفات الـ HTML والواجهات الثابتة
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();