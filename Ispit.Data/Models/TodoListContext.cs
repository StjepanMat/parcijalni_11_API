using Microsoft.EntityFrameworkCore;

namespace Ispit.Data.Models
{
    public partial class TodoListContext:DbContext
    {
        public TodoListContext()
        {
        }

        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
        }
        public virtual DbSet<TodoList> TodoList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=parcijalni_11_API;" +
                    "integrated security=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>( entity =>
            {
                entity.Property(e=> e.Id)
                .ValueGeneratedNever();

                entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Description)
                .HasMaxLength(300);

                entity.Property(e=> e.IsCompleted)
                .IsRequired();

            }

                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
