
# Design Decisions

## Problem
Convert numeric input to words as uppercase dollars/cents (e.g., `123.45` → `ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS`). Include negatives, zero, rounding to 2 decimal places, and correct plurals.

## Architecture
- **NumberToWordsConverter**: service containing conversion logic.
- **Minimal API**: HTTP layer with one endpoint `/convert`.
- **Static UI**: single `index.html` file for interactive testing.

## Key Choices
- **C# .NET 8 Minimal API**: lean scaffolding; quick delivery.
- **`decimal` for currency**: avoids float rounding pitfalls; explicit roudning to 2 decimal places.
- **Grammar**:
  - British-style "AND" for hundreds (e.g., `ONE HUNDRED AND FIVE`).
  - Hyphenate 21–99 (`TWENTY-ONE`).
  - Proper plurals (DOLLAR(S), CENT(S)).
- **Scales supported**: thousand, million, and billion.

## Alternatives Considered
- **Java**: heavier setup for this scope.
- **Floating-point types**: risk of rounding errors.
- **i18n & multi-currency**: out of scope; would introduce complexity.

## Complexity & Performance
Linear in number of digits; minimal CPU/memory usage. Suitable for synchronous API.

## Risks & Extensions
- **Locale rules**: extendable via strategy configuration (scale names, "AND" styles).
- **Very large numbers**: add more scales as needed.
- **Accessibility/UX**: current UI is simple but accessible; can add copy/share features.
