# ConnectionString_FromAppSettingsJSON_ASPCore6

# Supongamos que nuestro appsettings.json se ve así:

{
  "ConnectionStrings": {
    "myDb1": "Server=myServer;Database=myDb1;Trusted_Connection=True;",
    "myDb2": "Server=myServer;Database=myDb2;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

# En C# usaremos lo siguiente para leer la configuración:

Prerequisitos:
  -Instalar *Microsoft.Extensions.Configuration* desde NuGet
  
private readonly IConfiguration Configuration;

public ConeController(IConfiguration configuration)
{
    Configuration = configuration;
}

private string regresarCadenaConexion(){
  string cadenaConexion = Configuration["ConnectionStrings:myDb1"].ToString();
  return cadenaConexion;
}
