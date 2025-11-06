using FinalScore_Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalScore_Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<EquipoModel>   Equipos     { get; set; }
        public DbSet<JugadorModel>  Jugadores   { get; set; }
        public DbSet<LigaModel>     Ligas       { get; set; }
        
    }
}
