using NumberToWords.Api.Services;
using Xunit;

public class NumberToWordsConverterTests
{
    private readonly NumberToWordsConverter _conv = new();

    [Theory]
    [InlineData(0, "ZERO DOLLARS")]
    [InlineData(1, "ONE DOLLAR")]
    [InlineData(2, "TWO DOLLARS")]
    [InlineData(12, "TWELVE DOLLARS")]
    [InlineData(21, "TWENTY-ONE DOLLARS")]
    [InlineData(105, "ONE HUNDRED AND FIVE DOLLARS")]
    [InlineData(123.45, "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS")]
    [InlineData(-42.1, "NEGATIVE FORTY-TWO DOLLARS AND TEN CENTS")]
    [InlineData(1000, "ONE THOUSAND DOLLARS")]
    [InlineData(1001, "ONE THOUSAND AND ONE DOLLARS")]
    [InlineData(1105, "ONE THOUSAND ONE HUNDRED AND FIVE DOLLARS")]
    [InlineData(1000000, "ONE MILLION DOLLARS")]
    public void CurrencyToWords_Works(decimal amount, string expected)
    {
        Assert.Equal(expected, _conv.ConvertCurrencyToWords(amount));
    }

    [Theory]
    [InlineData(1.005, "ONE DOLLAR AND ONE CENT")]
    [InlineData(1.995, "TWO DOLLARS")] // rounds up to 2.00
    public void Rounding_Works(decimal amount, string expected)
    {
        Assert.Equal(expected, _conv.ConvertCurrencyToWords(amount));
    }
}
