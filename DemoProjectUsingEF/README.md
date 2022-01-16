# DemoProjectUsingEF

## Environment configuration
Project configuration is done via `appsettings.json` file and `appsettings.Development.json` files. 
The latter is being ignored by git so it should be requested from teammates. 

## Database models scaffolding
To create models for new database run the following cmd in the Package Manager Console:
```sh
Scaffold-DbContext "Server=<DB_URI>;Database=<DB_NAME>;User ID=<USER_ID>;Password=<PASSWORD>;Connection Timeout=90;TrustServerCertificate=True;Trusted_Connection=True;Integrated security=false" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataBases/<Database>/Models
```
`DB_URI`, `DB_NAME`, `Database`, `USER_ID` and `PASSWORD` field should be provided.

Please refer to the [article](https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx) for more info on running migrations.
