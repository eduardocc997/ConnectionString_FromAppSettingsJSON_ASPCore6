
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
