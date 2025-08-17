namespace NumberToWords.Api.Services
{
    public class NumberToWordsConverter
    {
        private static readonly string[] Units =
        {
            "ZERO","ONE","TWO","THREE","FOUR","FIVE","SIX","SEVEN","EIGHT","NINE",
            "TEN","ELEVEN","TWELVE","THIRTEEN","FOURTEEN","FIFTEEN","SIXTEEN","SEVENTEEN","EIGHTEEN","NINETEEN"
        };

        private static readonly string[] Tens =
        {
            "ZERO","TEN","TWENTY","THIRTY","FORTY","FIFTY","SIXTY","SEVENTY","EIGHTY","NINETY"
        };

        public string ConvertCurrencyToWords(decimal amount)
        {
            var negative = amount < 0;
            amount = Math.Abs(amount);

            // split value into dollars and cents (rounding to 2 decimal places)
            var dollarsPart = (long)decimal.Truncate(amount);
            var centsDecimal = decimal.Round((amount - dollarsPart) * 100m, 0, MidpointRounding.AwayFromZero);
            var centsPart = (int)centsDecimal;

            // handle rounding for edge case (e.g, 1.995 rounds to 2.00)
            if (centsPart == 100)
            {
                dollarsPart += 1;
                centsPart = 0;
            }

            var dollarsWords = ConvertWholeNumber(dollarsPart);
            var dollarsLabel = dollarsPart == 1 ? " DOLLAR" : " DOLLARS";

            string result;
            if (centsPart > 0)
            {
                var centsWords = ConvertWholeNumber(centsPart);
                var centsLabel = centsPart == 1 ? " CENT" : " CENTS";
                result = dollarsWords + dollarsLabel + " AND " + centsWords + centsLabel;
            }
            else
            {
                result = dollarsWords + dollarsLabel;
            }

            return negative ? "NEGATIVE " + result : result;
        }

        private static string ConvertWholeNumber(long n)
        {
            if (n < 20) return Units[n];
            if (n < 100) return ConvertTens((int)n);
            if (n < 1_000) return ConvertHundreds((int)n);
            if (n < 1_000_000) return JoinBig(n, 1_000, " THOUSAND");
            if (n < 1_000_000_000) return JoinBig(n, 1_000_000, " MILLION");
            if (n < 1_000_000_000_000) return JoinBig(n, 1_000_000_000, " BILLION");

            return n.ToString();
        }

        private static string ConvertTens(int n)
        {
            if (n < 20) return Units[n];
            var ten = n / 10;
            var unit = n % 10;
            return unit == 0 ? Tens[ten] : $"{Tens[ten]}-{Units[unit]}";
        }

        private static string ConvertHundreds(int n)
        {
            var hundreds = n / 100;
            var remainder = n % 100;
            var head = $"{Units[hundreds]} HUNDRED";
            if (remainder == 0) return head;
            return head + " AND " + (remainder < 20 ? Units[remainder] : ConvertTens(remainder));
        }

        private static string JoinBig(long n, long divisor, string scale)
        {
            var head = n / divisor;
            var remainder = n % divisor;

            var headWords = ConvertWholeNumber(head) + scale;
            if (remainder == 0) return headWords;

            // If the remainder is less than 100, use "AND" to connect
            var separator = remainder < 100 ? " AND " : " ";
            return headWords + separator + ConvertWholeNumber(remainder);
        }
    }
}
