using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.ToDoCada.Web.Razor.Domains
{
    public partial class TodoCasaContext : DbContext
    {
        public TodoCasaContext()
        {
        }

        public TodoCasaContext(DbContextOptions<TodoCasaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subtarefas> Subtarefas { get; set; }
        public virtual DbSet<Tarefas> Tarefas { get; set; }
        public virtual DbSet<TiposSubtarefas> TiposSubtarefas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.\\SQlSERVERJIROS; initial catalog=Todo_Casa; user id = sa;pwd=ji_15?27101001_roS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subtarefas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Concluido).HasColumnName("concluido");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TarefaId).HasColumnName("tarefa_Id");

                entity.Property(e => e.TipoSubtarefaId).HasColumnName("tipo_subtarefa_Id");

                entity.HasOne(d => d.Tarefa)
                    .WithMany(p => p.Subtarefas)
                    .HasForeignKey(d => d.TarefaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subtarefa__taref__3F466844");

                entity.HasOne(d => d.TipoSubtarefa)
                    .WithMany(p => p.Subtarefas)
                    .HasForeignKey(d => d.TipoSubtarefaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subtarefa__tipo___3E52440B");
            });

            modelBuilder.Entity<Tarefas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("dataCriacao")
                    .HasColumnType("datetime");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposSubtarefas>(entity =>
            {
                entity.ToTable("Tipos_Subtarefas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
