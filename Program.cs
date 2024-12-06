using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Interfaces;
using Progression.Repository;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Enables attribute routing
builder.Services.AddEndpointsApiExplorer(); // Adds support for API documentation
builder.Services.AddSwaggerGen(); // Adds Swagger for API documentation
builder.Services.AddHttpClient();

// Add the database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DevConnection")));

// Register repository as a scoped service
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React app's URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("AllowFrontend");
// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseHsts(); // Enforces HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseSwagger(); // Enable Swagger for API documentation
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Progression API V1");
    c.RoutePrefix = string.Empty; // Access Swagger at the root
});

app.UseStaticFiles(); // Serve static files if needed

app.UseRouting(); // Enable routing middleware

app.UseAuthorization(); // Enable authorization middleware

app.MapControllers(); // Map attribute-routed controllers

// Optional: Redirect root URL to API documentation or a specific endpoint
app.MapGet("/", () => Results.Redirect("/swagger"));

// Run the application
app.Run();
