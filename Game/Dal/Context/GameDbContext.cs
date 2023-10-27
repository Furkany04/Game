using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System.Reflection;

namespace Dal.Context
{
    public class GameDbContext:IdentityDbContext<User>
    {
        public GameDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=FURKAN;Database=Game;Integrated Security = true;TrustServerCertificate=true");
            //optionsBuilder.UseSqlServer(@"Server=FURKAN;Database=ITM_Test;Integrated Security = true;TrustServerCertificate=true");
            //optionsBuilder.UseSqlServer(@"Server=IBRAHIM_KAYA;Database=ITM_Firma;USER ID = ITM;PASSWORD = ITM2018;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Tek tek map dosyalarını config etmek için uygulanan : 
            //builder.ApplyConfiguration(new BreakConfig());...

            //Bütün config dosyalarını uygulamak için : 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
        //DbSet'ler gelecek
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
