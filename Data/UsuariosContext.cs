using Microsoft.EntityFrameworkCore;

namespace Usuarios.Data
{
    public class UsuariosContext : DbContext
    {
        public DbSet<Model.Usuarios> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=Usuarios;Uid=root;Pwd=root;";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

            optionsBuilder.UseMySql(connectionString, serverVersion);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Usuarios>(entity =>
            {
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.Nome).IsRequired();
            });
        }
    }
}