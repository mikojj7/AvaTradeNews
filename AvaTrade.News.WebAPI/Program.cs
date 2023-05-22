using AvaTrade.News.Infrastructure.Data.Extensions;
using AvaTrade.News.Application.Extensions;
using AvaTrade.News.Infrastructure.PolygonNewsFetcher.Extensions;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNewsDbContext(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    var polity = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.Filters.Add(new AuthorizeFilter(polity));
});

builder.Services.AddNewsDbContext(builder.Configuration);
builder.Services.AddPolygonNewsFetcher(builder.Configuration);
builder.Services.AddNewsServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
