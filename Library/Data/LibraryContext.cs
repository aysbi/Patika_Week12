using Library.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Category> Categories { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Library;Username=postgres;Password=asdmna;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                //entity.Property(e => e.Author).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PublicationYear).HasColumnName("Year");
                //entity.HasIndex(e => e.Author);

                entity.HasMany(e => e.Reviews).WithOne(e => e.Book).HasForeignKey(e => e.BookId).OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Detail).WithOne(e => e.Book).HasForeignKey<BookDetail>(e => e.BookId);

                entity.HasMany(e => e.Authors).WithMany(e => e.Books).UsingEntity(e => e.ToTable("BookAuthors"));
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(e => e.Books).WithOne(e => e.Category).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Cascade); 
                //many tarafinda foreign key olusturulur
            });   

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Reviews");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ReviewerName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Rating).HasColumnName("Stars");
            });


        }
    }
}
