using Microsoft.EntityFrameworkCore;
using Razor.LanHouse.Dominios;

namespace Razor.LanHouse.Contextos
{
    public partial class LanHouseContext : DbContext
    {
        public LanHouseContext()
        {

        }

        public LanHouseContext(DbContextOptions<LanHouseContext> options): base(options)
        {

        }

        public virtual DbSet<RegistrosDefeitos> RegistrosDefeitos { get; set; }
        public virtual DbSet<TiposDefeitos> TiposDefeitos { get; set; }
        public virtual DbSet<TiposEquipamentos> TiposEquipamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("connection-string");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrosDefeitos>(entity =>
            {
                entity.ToTable("RegistrosDefeitos");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.DataDefeito).HasColumnName("DataDefeito");

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDefeitoId).HasColumnName("TipoDefeitoId");

                entity.Property(e => e.TipoEquipamentoId).HasColumnName("TipoEquipamentoId");

                entity.HasOne(d => d.TipoDefeito)
                    .WithMany(p => p.RegistrosDefeitos)
                    .HasForeignKey(d => d.TipoDefeitoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registros__Tipo___3C69FB99");

                entity.HasOne(d => d.TipoEquipamento)
                    .WithMany(p => p.RegistrosDefeitos)
                    .HasForeignKey(d => d.TipoEquipamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registros__Tipo___3B75D760");
            });

            modelBuilder.Entity<TiposDefeitos>(entity =>
            {
                entity.ToTable("TiposDefeitos");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposEquipamentos>(entity =>
            {
                entity.ToTable("TiposEquipamentos");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("Senha")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
