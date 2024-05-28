using API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithOne(b => b.Publisher)
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Borrower>()
                .HasMany(b => b.Loans)
                .WithOne(l => l.Borrower)
                .HasForeignKey(l => l.BorrowerId);

            modelBuilder.Entity<Book>().Property(x => x.Price).HasPrecision(10, 5);

            var bookList = new Book[]
            {
                new Book { Id = 1, Title = "Game of Thrones", ISBN = "123456789", Price = 9.99m, PublisherId = 1 },
                new Book { Id = 2, Title = "A Feast of Dragons", ISBN = "GKKDF346", Price = 19.99m, PublisherId = 2 },
                new Book { Id = 3, Title = "Cracking the Coding Interview", ISBN = "GFOOSADOG", Price = 99.99m, PublisherId = 2 },
                new Book { Id = 4, Title = "A Storm of Swords", ISBN = "GIIGHJ32d", Price = 14.99m, PublisherId = 1 }
            };
            modelBuilder.Entity<Book>().HasData(bookList);

            var publisherList = new Publisher[]
            {
                new Publisher { Id = 1, Name = "Penguin" },
                new Publisher { Id = 2, Name = "Harper Collins" }
            };
            modelBuilder.Entity<Publisher>().HasData(publisherList);

            var authorList = new Author[]
            {
                new Author { Id = 1, Name = "George", Surname = "Martin", Email = "george.martn@gmail.com", BirthDate = new DateTime(1948, 9, 20)},
                new Author { Id = 2, Name = "Gayle", Surname = "Laakmann", Email = "gayle.laakmann@gmail.com", BirthDate = new DateTime(1979, 6, 19)}
            };
            modelBuilder.Entity<Author>().HasData(authorList);
        }
    }
}
