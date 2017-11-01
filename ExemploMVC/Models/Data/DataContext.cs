using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExemploMVC.Models.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public DataContext() : base("DB")
        {
        }

        #region Criação do banco via migration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region [Configurações gerais BD]
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(255));

            modelBuilder.Properties<bool>().Configure(p => p.HasColumnType("bit"));

            modelBuilder.Properties<decimal>().Configure(p => p.HasColumnType("money"));            modelBuilder.Properties<decimal>().Configure(p => p.HasPrecision(19, 2));
            #endregion
        }
        #endregion

    }
}