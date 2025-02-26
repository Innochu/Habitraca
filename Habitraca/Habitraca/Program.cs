
using Habitraca.Persistence.Extensions;
using Habitraca.Common;
using Habitraca.Domain.Entities;
using Habitraca.Persistence.DbContextFolder;
using Microsoft.AspNetCore.Identity;
using Habitraca.Application.Configurations;
using Habitraca.Application.Implementation;
using Habitraca.Application.Interface.Repositories;
using Habitraca.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationHelper.InstantiateConfiguration(builder.Configuration);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies(configuration);
builder.Services.ConfigureAuthentication(configuration);
builder.Services.EmailConfig(configuration);
// Register Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

            }).AddEntityFrameworkStores<HabitDbContext>().AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<RewardService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Habitraca-v1");
        c.RoutePrefix = "swagger";
    });
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
  // await Seeder.SeedRoles(serviceProvider);
}

app.UseCors();

app.UseHttpsRedirection();
app.UseAuthentication();


app.UseAuthorization();

app.MapGet("/api/rewards/get_all_rewards", async (RewardService rewardService) =>
{
    var response = await rewardService.GetAllRewards();
    return response.Succeeded ? Results.Ok(response) : Results.NotFound(response);
});

app.MapGet("/api/rewards/points/{points}", async (int points, RewardService rewardService) =>
{
    var response = await rewardService.GetRewardsByPoints(points);
    return response.Succeeded ? Results.Ok(response) : Results.NotFound(response);
});

app.MapGet("/api/rewards/search", async (string word, RewardService rewardService) =>
{
    var response = await rewardService.GetRewardsByWordSearch(word);
    return response.Succeeded ? Results.Ok(response) : Results.NotFound(response);
});

app.MapGet("/api/rewards/point_range", async (int minPoints, int maxPoints, RewardService rewardService) =>
{
    var response = await rewardService.GetRewardsByPointsRange(minPoints, maxPoints);
    return response.Succeeded ? Results.Ok(response) : Results.NotFound(response);
});
//you can use carter nugget package module to better organize this minimal api

app.MapControllers();

app.Run();
