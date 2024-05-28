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
                new Book { Id = 4, Title = "A Storm of Swords", ISBN = "GIIGHJ32d", Price = 14.99m, PublisherId = 1 },
                new Book { Id = 5, Title = "The Catcher in the Rye", ISBN = "ISBN-345678901", Price = 11.25m, PublisherId = 1 },
                new Book { Id = 6, Title = "Harry Potter and the Philosopher's Stone", ISBN = "ISBN-876543210", Price = 15.99m, PublisherId = 1 },
                new Book { Id = 7, Title = "To the Lighthouse", ISBN = "ISBN-567890123", Price = 14.50m, PublisherId = 2 },
                new Book { Id = 8, Title = "Moby-Dick", ISBN = "ISBN-210987654", Price = 13.25m, PublisherId = 1 },
                new Book { Id = 9, Title = "The Hobbit", ISBN = "ISBN-789012345", Price = 16.75m, PublisherId = 1 },
                new Book { Id = 10, Title = "Lord of the Flies", ISBN = "ISBN-321098765", Price = 10.99m, PublisherId = 2 },
                new Book { Id = 11, Title = "Brave New World", ISBN = "ISBN-654321098", Price = 9.50m, PublisherId = 2 },
                new Book { Id = 12, Title = "Wuthering Heights", ISBN = "ISBN-543210987", Price = 8.25m, PublisherId = 1 },
                new Book { Id = 13, Title = "The Grapes of Wrath", ISBN = "ISBN-432109876", Price = 11.75m, PublisherId = 2 },
                new Book { Id = 14, Title = "One Hundred Years of Solitude", ISBN = "ISBN-210987654", Price = 14.99m, PublisherId = 2 },
                new Book { Id = 15, Title = "The Lord of the Rings", ISBN = "ISBN-789012345", Price = 17.50m, PublisherId = 1 },
                new Book { Id = 16, Title = "Animal Farm", ISBN = "ISBN-543210987", Price = 12.25m, PublisherId = 2 },
                new Book { Id = 17, Title = "Fahrenheit 451", ISBN = "ISBN-654321098", Price = 15.75m, PublisherId = 1 },
                new Book { Id = 18, Title = "Gone with the Wind", ISBN = "ISBN-432109876", Price = 10.99m, PublisherId = 1 },
                new Book { Id = 19, Title = "The Odyssey", ISBN = "ISBN-321098765", Price = 9.50m, PublisherId = 2 },
                new Book { Id = 20, Title = "Crime and Punishment", ISBN = "ISBN-789012345", Price = 14.25m, PublisherId = 1 },
                new Book { Id = 21, Title = "The Great Gatsby", ISBN = "ISBN-123456789", Price = 12.99m, PublisherId = 2 },
                new Book { Id = 22, Title = "To Kill a Mockingbird", ISBN = "ISBN-987654321", Price = 10.50m, PublisherId = 1 },
                new Book { Id = 23, Title = "1984", ISBN = "ISBN-234567890", Price = 9.99m, PublisherId = 1 },
                new Book { Id = 24, Title = "Pride and Prejudice", ISBN = "ISBN-098765432", Price = 8.75m, PublisherId = 2 }

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
                new Author { Id = 2, Name = "Gayle", Surname = "Laakmann", Email = "gayle.laakmann@gmail.com", BirthDate = new DateTime(1979, 6, 19)},
                new Author { Id = 3, Name = "Simon", Surname = "Collins", Email = "simon.collins@gmail.com", BirthDate = new DateTime(1965, 3, 19)},
                new Author { Id = 4, Name = "Sarah", Surname = "Brown", Email = "sarah.brown@example.com", BirthDate = new DateTime(1990, 12, 8) },
                new Author { Id = 5, Name = "Michael", Surname = "Jones", Email = "michael.jones@example.com", BirthDate = new DateTime(1972, 7, 15) },
                new Author { Id = 6, Name = "Rachel", Surname = "Miller", Email = "rachel.miller@example.com", BirthDate = new DateTime(1985, 2, 28) },
                new Author { Id = 7, Name = "David", Surname = "Martinez", Email = "david.martinez@example.com", BirthDate = new DateTime(1968, 10, 3) },
                new Author { Id = 8, Name = "Jessica", Surname = "Garcia", Email = "jessica.garcia@example.com", BirthDate = new DateTime(1983, 6, 12) },
                new Author { Id = 9, Name = "Kevin", Surname = "Taylor", Email = "kevin.taylor@example.com", BirthDate = new DateTime(1977, 4, 17) },
                new Author { Id = 10, Name = "Michelle", Surname = "Lee", Email = "michelle.lee@example.com", BirthDate = new DateTime(1995, 8, 22) }

            };
            modelBuilder.Entity<Author>().HasData(authorList);

        }
    }
}
