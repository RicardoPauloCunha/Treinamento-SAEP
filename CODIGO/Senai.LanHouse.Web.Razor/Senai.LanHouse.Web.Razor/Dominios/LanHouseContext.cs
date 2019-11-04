using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.LanHouse.Web.Razor.Dominios
{
    public partial class LanHouseContext : DbContext
    {
        public LanHouseContext()
        {
        }

        public LanHouseContext(DbContextOptions<LanHouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegistrosDefeitos> RegistrosDefeitos { get; set; }
        public virtual DbSet<TiposDefeitos> TiposDefeitos { get; set; }
        public virtual DbSet<TiposEquipamentos> TiposEquipamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source =.\\SQLSERVER; Initial Catalog=Lan_House; User id=sa;pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrosDefeitos>(entity =>
            {
                entity.ToTable("Registros_Defeitos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDefeito).HasColumnName("Data_Defeito");

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDefeitoId).HasColumnName("Tipo_Defeito_Id");

                entity.Property(e => e.TipoEquipamentoId).HasColumnName("Tipo_Equipamento_Id");

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
                entity.ToTable("Tipos_Defeitos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposEquipamentos>(entity =>
            {
                entity.ToTable("Tipos_Equipamentos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
