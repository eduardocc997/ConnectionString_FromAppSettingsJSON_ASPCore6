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

===========================================================================================
# En C#, cargarlo desde *Program.cs* y conectar con SQL Server
Prerequisitos:
  -Instalar *Microsoft.Extensions.Configuration* desde NuGet
  -Instalar *Microsoft.EntityFrameworkCore* desde NuGet
  -Haber creado la entidad y el DBContext de la base de datos
Codigo del Context y Entity:
# Entity:
*Este debe corresponder con los datos de la tabla*
using System.ComponentModel.DataAnnotations;

namespace MotosAPI.Entities
{
    public class Motos
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string marca { get; set; }
        [Required]
        public string modelo { get; set; }
        [Required]
        public int cc { get; set; }
    }
}


# Context:
using Microsoft.EntityFrameworkCore;
using MotosAPI.Entities;

namespace MotosAPI.Context
{
    public class MotosDBContext: DbContext
    {
        public MotosDBContext(DbContextOptions<MotosDBContext> options): base(options)
        {

        }

        public DbSet<Motos> Motos { get; set; }
    }
}


Esto dentro del archivo *Program.cs*

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
var root = configurationBuilder.Build();
var cadenaConexion = root.GetConnectionString("myDb1");
builder.Services.AddDbContext<MotosDBContext>(options => options.UseSqlServer(cadenaConexion));
