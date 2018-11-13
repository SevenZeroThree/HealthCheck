# HealthCheck

[![Build status](https://sevenzerothree.visualstudio.com/Health%20Check/_apis/build/status/HealthCheck.Main)](https://sevenzerothree.visualstudio.com/Health%20Check/_build/latest?definitionId=8)

A NuGet package that provides HealthCheck functionality for .NET Core applications

## Usage

After installing the package into a .NET Core MVC or Web Api project, the Health Check behavior can be initialized by adding the following:

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

Once the Health Check behavior has been initialized, navigate to `~/health` to view the Health page. It will look like the following:

```
Online

11/12/2018 20:13:40

```
