using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;
using BookManagement.Infrastructure.Repositories;
using BookManagement.Services;
using BookManagement.Services.Helpers.Profiles.AuthorProfile;
using BookManagement.Services.Helpers.Profiles.BookProfile;
using BookManagement.Services.Helpers.Profiles.PublisherProfile;
using BookManagement.Services.Services;
using BookManagement.Services.Validators;
using BookManagement.Services.Validators.AuthorValidator;
using BookManagement.Services.Validators.BookValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookManagementContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 4, 0))));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();

builder.Services.AddAutoMapper(typeof(AuthorProfile), typeof(BookProfile), typeof(PublisherProfile));

builder.Services.AddValidatorsFromAssemblyContaining<AuthorBaseDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BookBaseDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PublisherBaseDTOValidator>();

// Register FluentValidation validators
builder.Services.AddValidatorsFromAssemblyContaining<AuthorCreateDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AuthorUpdateDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PublisherCreateDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<PublisherUpdateDTOValidator>();

// ✅ Correct Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseExceptionHandler("/error");

app.MapControllers();

// Example endpoint
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

