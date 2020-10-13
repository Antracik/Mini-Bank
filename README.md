# Mini-Bank
A summer (2019) project for introduction to C# and .net core 2.2

##Prerequisites to compiling and running the project:

.net core 2.2: https://dotnet.microsoft.com/download/dotnet-core/2.2

sql Server Dev edition: https://www.microsoft.com/en-us/sql-server/sql-server-downloads

The connection string from sql server must be placed in MiniBank/appsettings.json : 

```json
"ConnectionStrings": {
    "MiniBankDB": "YOUR CONN STRING HERE"
  }
```

  In order for the email service to work an API key for SENDGRID https://sendgrid.com/ is required
  Once acquired, your username and key need to placed in the project as local user secrets. It can be done through the CLI as follows:
  
  ```cs
  dotnet user-secrets set SendGridUser <username>
  dotnet user-secrets set SendGridKey <key>
  ```
