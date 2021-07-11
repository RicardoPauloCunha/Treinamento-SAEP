using Microsoft.EntityFrameworkCore;

namespace Razor.ToDoCasa.Domains
{
    public partial class TodoCasaContext : DbContext
    {
        public TodoCasaContext()
        {

        }

        public TodoCasaContext(DbContextOptions<TodoCasaContext> options): base(options)
        {

        }

        public virtual DbSet<Subtarefas> Subtarefas { get; set; }
        public virtual DbSet<Tarefas> Tarefas { get; set; }
        public virtual DbSet<TiposSubtarefas> TiposSubtarefas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connection-string");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subtarefas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Concluido).HasColumnName("Concluido");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("Descricao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TarefaId).HasColumnName("TarefaId");

                entity.Property(e => e.TipoSubtarefaId).HasColumnName("TipoSubtarefaId");

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
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("DataCriacao")
                    .HasColumnType("Datetime");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("Titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposSubtarefas>(entity =>
            {
                entity.ToTable("TiposSubtarefas");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("Senha")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
