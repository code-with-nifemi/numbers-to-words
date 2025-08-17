using System.Globalization;
using NumberToWords.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddSingleton<NumberToWordsConverter>();

var app = builder.Build();

// serve index.html
app.UseDefaultFiles();
app.UseStaticFiles();

// GET /convert?amount=123.45
app.MapGet("/convert", (string? amount, NumberToWordsConverter converter) =>
{
    if (string.IsNullOrWhiteSpace(amount))
        return Results.BadRequest("Please enter an amount to convert");

    if (!decimal.TryParse(amount, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
        return Results.BadRequest("Please enter a valid number (e.g., 123.45)");

    var words = converter.ConvertCurrencyToWords(value);
    return Results.Ok(new { input = amount, words });
});

app.Run();
