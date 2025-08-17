# Test Plan

## Scope
Validate functional correctness of number-to-words conversion and HTTP interface.

## Methods
- **Unit tests** (xUnit) for converter.
- **Manual tests** via `index.html` for end-to-end.

## Equivalence Classes
- Zero: 0 → `ZERO DOLLARS`
- One: 1 → `ONE DOLLAR`
- 2–9, 10–19, 20–99 (hyphenation), 100–999 (with "AND"), >=1000 (scales)
- Cents: `.01`–`.99`
- Negatives: `-x.yy`

## Boundaries
- 99 ↔ 100 (e.g., 99, 100)
- 999 ↔ 1000 (e.g., 999, 1000, 1001, 1105)
- Rounding: 1.005 → `ONE DOLLAR AND ONE CENT`; 1.995 → `TWO DOLLARS`

## Invalid Inputs (API)
- Missing `amount`
- Non-numeric `amount=abc`
- Locale mismatches (comma as decimal)
- Extremely large inputs (beyond supported scales)

## Pass/Fail Examples
| Input    | Expected                                                        | Result |
|----------|-----------------------------------------------------------------|--------|
| 0        | ZERO DOLLARS                                                    | Pass   |
| 1        | ONE DOLLAR                                                      | Pass   |
| 12       | TWELVE DOLLARS                                                  | Pass   |
| 21       | TWENTY-ONE DOLLARS                                              | Pass   |
| 105      | ONE HUNDRED AND FIVE DOLLARS                                    | Pass   |
| 123.45   | ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS       | Pass   |
| -42.1    | NEGATIVE FORTY-TWO DOLLARS AND TEN CENTS                        | Pass   |
| 1000     | ONE THOUSAND DOLLARS                                            | Pass   |
| 1001     | ONE THOUSAND AND ONE DOLLARS                                    | Pass   |
| 1105     | ONE THOUSAND ONE HUNDRED AND FIVE DOLLARS                       | Pass   |
| 1.005    | ONE DOLLAR AND ONE CENT                                         | Pass   |
| 1.995    | TWO DOLLARS                                                     | Pass   |
| (invalid)| 400 Bad Request with helpful message                            | Pass   |