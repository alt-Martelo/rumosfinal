using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project1_Angular.Models;

namespace Project1_Angular.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {}
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<IngredienteReceita> IngredienteReceitas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredienteReceita>()
                .HasKey(ir => new { ir.ReceitaId, ir.IngredienteId });

            modelBuilder.Entity<IngredienteReceita>()
                .HasOne(ir => ir.Receita)
                .WithMany(r => r.Ingredientes)
                .HasForeignKey(ir => ir.ReceitaId);

            modelBuilder.Entity<IngredienteReceita>()
                .HasOne(ir => ir.Ingrediente)
                .WithMany(i => i.IngredienteReceitas)
                .HasForeignKey(ir => ir.IngredienteId);
        }
    }
}
}