using API.Core.Entities;
using API.Core.Models;
using Microsoft.Data.SqlClient;
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
        public DbSet<FilteredBooks> FilteredBooks { get; set; }
        public DbSet<BorrowersByBookId> BorrowersByBookId { get; set; }

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

            modelBuilder.Entity<FilteredBooks>().HasNoKey();
            modelBuilder.Entity<BorrowersByBookId>().HasNoKey();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Loan>().Property(l => l.ReturnDate).HasColumnType("datetime2");

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

            var borrowersList = new Borrower[]
            {
                new Borrower { Id = 1, Name = "Ron", Surname = "Walker", Email = "ron.walker@example.com", PhoneNumber = "3806747254818" },
                new Borrower { Id = 2, Name = "Jane", Surname = "Doe", Email = "jane.doe@example.com", PhoneNumber = "380671234567" },
                new Borrower { Id = 3, Name = "John", Surname = "Smith", Email = "john.smith@example.com", PhoneNumber = "380671234568" },
                new Borrower { Id = 4, Name = "Emily", Surname = "Johnson", Email = "emily.johnson@example.com", PhoneNumber = "380671234569" },
                new Borrower { Id = 5, Name = "Michael", Surname = "Brown", Email = "michael.brown@example.com", PhoneNumber = "380671234570" },
                new Borrower { Id = 6, Name = "Jessica", Surname = "Davis", Email = "jessica.davis@example.com", PhoneNumber = "380671234571" },
                new Borrower { Id = 7, Name = "David", Surname = "Miller", Email = "david.miller@example.com", PhoneNumber = "380671234572" },
                new Borrower { Id = 8, Name = "Sarah", Surname = "Wilson", Email = "sarah.wilson@example.com", PhoneNumber = "380671234573" },
                new Borrower { Id = 9, Name = "Daniel", Surname = "Moore", Email = "daniel.moore@example.com", PhoneNumber = "380671234574" },
                new Borrower { Id = 10, Name = "Laura", Surname = "Taylor", Email = "laura.taylor@example.com", PhoneNumber = "380671234575" }
            };
            modelBuilder.Entity<Borrower>().HasData(borrowersList);

            var loansList = new Loan[]
            {
                new Loan { Id = 1, BookId = 12, BorrowerId = 2, LoanDate = new DateTime(2022, 2, 24), ReturnDate = new DateTime(2022, 4, 24) },
                new Loan { Id = 2, BookId = 5, BorrowerId = 1, LoanDate = new DateTime(2022, 1, 15), ReturnDate = new DateTime(2022, 3, 15) },
                new Loan { Id = 3, BookId = 7, BorrowerId = 3, LoanDate = new DateTime(2023, 3, 10), ReturnDate = new DateTime(2023, 5, 10) },
                new Loan { Id = 4, BookId = 2, BorrowerId = 4, LoanDate = new DateTime(2023, 4, 12), ReturnDate = new DateTime(2023, 6, 12) },
                new Loan { Id = 5, BookId = 8, BorrowerId = 5, LoanDate = new DateTime(2022, 5, 5), ReturnDate = new DateTime(2022, 7, 5) },
                new Loan { Id = 6, BookId = 10, BorrowerId = 6, LoanDate = new DateTime(2023, 6, 1), ReturnDate = new DateTime(2023, 8, 1) },
                new Loan { Id = 7, BookId = 4, BorrowerId = 7, LoanDate = new DateTime(2022, 7, 20), ReturnDate = new DateTime(2022, 9, 20) },
                new Loan { Id = 8, BookId = 6, BorrowerId = 8, LoanDate = new DateTime(2023, 8, 15), ReturnDate = new DateTime(2023, 10, 15) },
                new Loan { Id = 9, BookId = 9, BorrowerId = 9, LoanDate = new DateTime(2022, 9, 30), ReturnDate = new DateTime(2022, 11, 30) },
                new Loan { Id = 10, BookId = 11, BorrowerId = 10, LoanDate = new DateTime(2023, 10, 1), ReturnDate = new DateTime(2023, 12, 1) },
                new Loan { Id = 11, BookId = 12, BorrowerId = 1, LoanDate = new DateTime(2023, 1, 10), ReturnDate = new DateTime(2023, 3, 10) },
                new Loan { Id = 12, BookId = 12, BorrowerId = 3, LoanDate = new DateTime(2023, 2, 15), ReturnDate = new DateTime(2023, 4, 15) },
                new Loan { Id = 13, BookId = 12, BorrowerId = 4, LoanDate = new DateTime(2023, 5, 20), ReturnDate = new DateTime(2023, 7, 20) },
                new Loan { Id = 14, BookId = 12, BorrowerId = 5, LoanDate = new DateTime(2023, 3, 25), ReturnDate = new DateTime(2023, 5, 25) },
                new Loan { Id = 15, BookId = 12, BorrowerId = 6, LoanDate = new DateTime(2023, 6, 30), ReturnDate = new DateTime(2023, 8, 30) },
                new Loan { Id = 16, BookId = 12, BorrowerId = 7, LoanDate = new DateTime(2023, 4, 5), ReturnDate = new DateTime(2023, 6, 5) },
                new Loan { Id = 17, BookId = 12, BorrowerId = 8, LoanDate = new DateTime(2023, 7, 10), ReturnDate = new DateTime(2023, 9, 10) },
                new Loan { Id = 18, BookId = 12, BorrowerId = 9, LoanDate = new DateTime(2023, 5, 15), ReturnDate = new DateTime(2023, 7, 15) },
                new Loan { Id = 19, BookId = 12, BorrowerId = 10, LoanDate = new DateTime(2023, 8, 20), ReturnDate = new DateTime(2023, 10, 20) },
                new Loan { Id = 20, BookId = 12, BorrowerId = 2, LoanDate = new DateTime(2023, 9, 25), ReturnDate = new DateTime(2023, 11, 25) }

            };
            modelBuilder.Entity<Loan>().HasData(loansList);
        }

        public async Task<List<FilteredBooks>> GetFilteredBooksAsync (BookFilter bookFilter)
        {
            var titleParam = new SqlParameter("@Title", bookFilter.Title ?? (object)DBNull.Value);
            var authorsParam = new SqlParameter("@Authors", string.Join(",", bookFilter.Authors));

            var result = await FilteredBooks.FromSqlRaw("EXEC [dbo].[GetFilteredBooksWithAuthors] @Title, @Authors", titleParam, authorsParam)
                                            .ToListAsync();

            return result;
        }

        public async Task<List<BorrowersByBookId>> GetBorrowersByBookIdAsync (int bookId)
        {
            var bookIdParam = new SqlParameter("@bookId", bookId);

            var result = await BorrowersByBookId.FromSqlRaw("EXEC [dbo].[GetBorrowersByBookId] @bookId", bookIdParam)
                                                .ToListAsync();
            return result;
        }

    }
}
