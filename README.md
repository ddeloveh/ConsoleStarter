# ConsoleStarter
 Example starter console targeting net6.

This adds example configurations for Development and Production with an optional "appsettings.local.json".  This is added as optional so it can override when developing, but not sent to git. Added last so values in this will always be used.

Examples show getting a generic key as well as a connection string for a DB.

Logging is being sent to the console.

The launchSettings.json file includes the "DOTNET_ENVIRONMENT" to force it "DEVELOPMENT".