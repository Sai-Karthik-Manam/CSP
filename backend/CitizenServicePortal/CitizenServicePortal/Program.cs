
using CSP.API.Repositories.Implementations;
using CSP.API.Repositories.Interfaces;
using CSP.API.Services.Implementations;
using CSP.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IAuthServices,AuthServices>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("React",policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();
app.UseCors("React");
app.UseAuthorization();

app.MapControllers();

app.Run();
