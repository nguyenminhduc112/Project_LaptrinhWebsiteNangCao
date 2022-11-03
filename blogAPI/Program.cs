using blogAPI.Data;
using Microsoft.EntityFrameworkCore;
using blogAPI.Responsitories;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Code kết nối database
builder.Services.AddDbContext<AppDbContext>(Options=>{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<UserRespository>();
builder.Services.AddScoped<ArticleRespository>();
builder.Services.AddControllers();
var policyName = "myAppPolicy";
builder.Services.AddCors(options=>{
    options.AddPolicy(policyName,opt=>{
        opt.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
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
app.UseCors(policyName);
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
