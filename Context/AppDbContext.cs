using Microsoft.EntityFrameworkCore;
using ToDoMVC.Models;

namespace ToDoMVC.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TaskToDo> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskToDo>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<TaskToDo>()
                .Property(x => x.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            modelBuilder.Entity<TaskToDo>()
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(250);

            modelBuilder.Entity<TaskToDo>().Property(x => x.Date)
                .HasColumnType("datetime");
        }
    }
}
