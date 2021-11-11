namespace MotosAPI.Context
{
    public class DbConections
    {
        private readonly IConfiguration Configuration;
        private DbConections(IConfiguration configuration) 
        { 
            Configuration = configuration; 
        }

        private string getMotosConnectionString() { 
            string cadenaConexion = Configuration["ConnectionStrings:myDb1"].ToString(); 
            return cadenaConexion; 
        }
    }
}
