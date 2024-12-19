using Microsoft.EntityFrameworkCore;
using Progression.Data;
using Progression.Interfaces;
using Progression.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add the database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddAuthorization(); // Identity api endpoints
builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();




// Add services to the container.
builder.Services.AddControllers(); // Enables attribute routing
builder.Services.AddEndpointsApiExplorer(); // Adds support for API documentation
builder.Services.AddSwaggerGen(); // Adds Swagger for API documentation
builder.Services.AddHttpClient(); // Adds third party services

// Register repository as a scoped service
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IMilestoneRepository, MilestoneRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


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
app.MapIdentityApi<ApplicationUser>();

app.MapPost("/logout", async (SignInManager<ApplicationUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization();

app.MapPost("/pingauth", (ClaimsPrincipal user) =>
{
    var email = user.FindFirstValue(ClaimTypes.Email);
    return Results.Json(new { Email = email });
}).RequireAuthorization();

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
