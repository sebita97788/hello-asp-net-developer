using Acme.Hello.Platform.Profiles.Domain.Services;
using Acme.Hello.Platform.Profiles.Domain.Services.Internal;
using Acme.Hello.Platform.Profiles.Interfaces.Rest;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddValidation();

builder.Services.AddSingleton<IGreetingCounter, GreetingCounter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Hello ASP.NET Developer API")
            .WithTheme(ScalarTheme.DeepSpace)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.MapGreetingEndpoints();

app.Run();