# muddyWeather


## Project Secrt Values Setup

### from command line:
dotnet user-secrets set "muddyWeather:openWeatherApiKey" "<ApiKeyValue>" --project "<WepAppProjectPath>"

dotnet user-secrets set "muddyWeather:openWeatherApiKey" "<ApiKeyValue>" --project "<MsTestProjectPath>"


## Nuget Packges used:

the following were addd autmaticly by the project templates:

### Asp.Net Core Project Template Packages:
- Microsoft.VisualStudio.Azure.Containers.Tools.Targets

### MSTest Project Template Packages:
- Microsoft.NET.Test.Sdk
- MSTest.TestAdapter
- MSTest.TestFramework
- coverlet.collector

### Extra Packages:
- RestSharp: used to communicate with rest APIs
- Microsoft.Extensions.Configuration.UserSecrets: used to set up local machine secreats such as api keys
- Moq: used to mock dependincy interfaces when running unit tests

## Refrences used:
### Most Complete MSTest Unit Testing Framework Cheat Sheet:
https://www.automatetheplanet.com/mstest-cheat-sheet/

Refrenced when creating the ms test classes to fill them with the initial stub functions for testing

### Safe storage of app secrets in development in ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows

Refrenced when setting up the application for open weather aoi key value

### OpenWeatherMap Sign Up Page
https://home.openweathermap.org/users/sign_up

Refrenced to create a developer account on the open weather protal and obtain an api key

### OpenWeatherMap One Call Api Refrence Page
https://openweathermap.org/api/one-call-api
  
Refrenced when sytarting to consume the Open Weather Api
