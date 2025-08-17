# Number To Words Converter

A .NET Web API service that converts numeric values to their word representations.

## Project Structure

- `NumberToWords.Api/` - ASP.NET Core Web API project containing the conversion service
- `NumberToWords.Tests/` - Unit test project for testing the conversion logic

## Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code

## Getting Started

1. Clone the repository
```sh
git clone https://github.com/code-with-nifemi/number-to-words.git
cd number-to-words
```

2. Build the solution
```sh 
dotnet build
```

3. Run the tests
```sh
dotnet test
```

4. Run the API locally
```sh
cd NumberToWords.Api
dotnet run
```

The API will be available at `https://localhost:5001`

## API Usage

Send HTTP requests to convert numbers to words:

```http
GET /api/convert/{number}
```

Example:
```http
GET /api/convert/42

Response:
{
    "words": "forty-two"
}
```

## Development

- The solution follows standard .NET conventions
- Unit tests are written using xUnit
- API implemented using ASP.NET Core Web API
- Service layer handles the number-to-words conversion logic

## Contributing

1. Fork the repo
2. Create a feature branch
3. Commit your changes
4. Push to your branch
5. Open a Pull Request

## Notes on approach

My primary background is in Python, but for this task I chose C# as one of the requested options. This gave me the chance to quickly learn and apply new tools while still ensuring correctness through testing and documentation. I see this adaptability as reflective of how I would approach real-world projects at TechnologyOne: applying my existing strengths while ramping up quickly in new environments.

To complete this task within the required timeframe, I leveraged AI tools to assist with structuring the project and expediting routine coding tasks. I then refined, tested, and documented the solution myself. This reflects how I approach problem-solving in practice: using available resources effectively, while ensuring I fully understand and can explain every component of the final product.

I believe this mirrors real-world software development, where engineers use frameworks, libraries, and modern tools (including AI) to deliver value quickly while maintaining quality.