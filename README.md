# cyara-coding-test
Giang's work for Cyara interview coding challenge

## Technologies:
  * .NET 5
  * Angular 10
  * In-memory database

## Build App

Build solution in Visual Studio, or run the following command in project root folder:

```
dotnet build
```

## Run App

I used ASP.NET Core Web Application + Angular template in Visual Studio to implement the app so the frontend app will be hosted by the same .NET application

Run with F5 in Visual Studio, or with the following command in project root folder:

```
dotnet run --project CyaraCodingTest.Web
```

If run from Visual Studio, the web app can be accessed at:

```
https://localhost:44306
```

If run from command line, the web app can be accessed at:

```
https://localhost:5001
```

A default admin user is populated at app initialization with the following credentials:

```
User name: admin
Password: Password@123
```

## Functionalities that are included

  * Login Screen for registered token admins
  * A public endpoint for logging in as an admin user
  * A public endpoint for validating the invite token
  * Admin endpoints (with JWT authentication) for:
    * Generating new token
    * Listing all tokens
  
  * List/table of active and inactive tokens and relevant data (without search and pagination functionalities)
  * Ability to logout

## Things that I will add to the solution if I have more time

  * Nice-to-have functionalities 
    * UI and an endpoint to recall/disable issues invite tokens
    * Pagination or infinite scroll
    * Real database
  * Coding
    * Validation of input (e.g. validation of App URL)
    * Logging
    * More error handling
  * Tests including unit tests and integration tests for server-side code and end-to-end code with the frontend



