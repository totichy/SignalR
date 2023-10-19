using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using SignalR;
using SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
//builder.Services.AddSignalR(options => {
//    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllDomains", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("https://localhost:3000")
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials()); // allow credentials
}

app.UseRouting();
app.UseCors("AllDomains");
app.UseHttpsRedirection();
app.MapControllers();
app.MapHub<ChatHub>("/hubs/chat");
app.Run();

