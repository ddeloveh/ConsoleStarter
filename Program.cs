using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// See https://aka.ms/new-console-template for more information

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
    {
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
        //appsetting.json & appsettings.{Environment}.json are loaded by default
        // so this just adds an optional override file you wouldn't commit to git
        configurationBuilder.AddJsonFile("appsettings.local.json", optional: true);
    })
    .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
    {
        loggingBuilder.AddConsole();
    })
    .Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("A message being logged.");

var config = host.Services.GetRequiredService<IConfiguration>();

//Example of a config retrieval
var key1 = config.GetValue<string>("Key1", "Default for MISSING");
logger.LogInformation($"Key1={key1}");

var dbConnectionString = config.GetConnectionString("DB1");
logger.LogInformation($"DB1={dbConnectionString}");


Console.WriteLine("Press any key to exit...");
Console.ReadKey();