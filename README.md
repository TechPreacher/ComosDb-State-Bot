# ComosDb State Bot

A fully working sample of a Microsoft Bot Framework Bot that uses CosmosDB to store Custom State Data.

This sample builds on the blog post ["Manage custom state data with Azure Cosmos DB for .NET"](https://docs.microsoft.com/en-us/bot-framework/dotnet/bot-builder-dotnet-state-azure-cosmosdb) and is a fully implemented sample of the default [Visual Studio Bot Project Template](http://aka.ms/bf-bc-vstemplate) Sample.

## Prerequisites

### Set up the Azure Cosmos DB database
1. After you’ve logged into the Azure portal, create a new Azure Cosmos DB database by clicking *New*. 
2. Click *Databases*. 
3. Find *Azure Cosmos DB* and click *Create*.
4. Fill in the fields. For the *API* field, select *SQL (DocumentDB)*. When done filling in all the fields, click the *Create* button at the bottom of the screen to deploy the new database. 
5. After the new database is deployed, navigate to your new database. Click *Access keys* to find keys and connection strings. Your bot will use this information to call the storage service to save state data.

### Install NuGet packages
1. Open an existing C# bot project, or create a new one using the Bot template in Visual Studio. 
2. Install the following NuGet packages:

- Microsoft.Bot.Builder.Azure
- Autofac.WebApi2

**Make sure to update all NuGet Packages! The project may not compile without the latest versions!**

Replace the *CosmosDB URI* and *CosmosDB Key* in the Web.config file with the values displayed in the Azure Portal.

### Run your bot app
Run your bot in Visual Studio, the code you added will create the custom *botdata* table in Azure CosmosDB.

### Connect your bot to the emulator
At this point, your bot is running locally. Next, start the emulator and then connect to your bot in the emulator:

1. Type http://localhost:port-number/api/messages into the address bar, where port-number matches the port number shown in the browser where your application is running. You can leave *Microsoft App ID* and *Microsoft App Password* fields blank for local testing.
2. Click *Connect*. 
3. Test your bot by typing a few messages in the emulator.

### View state data on Azure Portal
To view the state data, sign into your Azure portal and navigate to your database. Click *Data Explorer* to verify that the state information from your bot is being saved. 