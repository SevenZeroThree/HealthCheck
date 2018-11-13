# HealthCheck

[![Build status](https://sevenzerothree.visualstudio.com/Health%20Check/_apis/build/status/HealthCheck.Main)](https://sevenzerothree.visualstudio.com/Health%20Check/_build/latest?definitionId=8)

A NuGet package that provides HealthCheck functionality for .NET Core applications

## Usage

#### Startup.cs
```c#
using HealthCheck.Mvc;

public void ConfigureServices(IServiceCollection services)
{
  ...
  services.AddHealthCheck();
  ...
}
```
