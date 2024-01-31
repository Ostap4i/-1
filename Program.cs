using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AfterHoliday
{

    class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public Book(string title, Author author, string genre, decimal price)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Price = price;
        }

        internal void Display()
        {
            throw new NotImplementedException();
        }
    }

    
    class Author
    {
        public string Name { get; set; }

        public Author(string name)
        {
            Name = name;
        }
    }

  
    abstract class BookDecorator : Book
    {
        protected Book book;

        public BookDecorator(Book book) : base(book.Title, book.Author, book.Genre, book.Price)
        {
            this.book = book;
        }

        public abstract void Display();
    }

    class CoverDecorator : BookDecorator
    {
        public string Cover { get; set; }

        public CoverDecorator(Book book, string cover) : base(book)
        {
            Cover = cover;
        }

        public override void Display()
        {
            Console.WriteLine($"Book: {book.Title}\n, Author: {book.Author.Name}\n, Genre: {book.Genre}\n, Price: {book.Price}\n, Cover: {Cover}\n");
        }
    }


    class ReviewDecorator : BookDecorator
    {
        public string Review { get; set; }

        public ReviewDecorator(Book book, string review) : base(book)
        {
            Review = review;
        }

        public override void Display()
        {
            Console.WriteLine($"Book: {book.Title}, Author: {book.Author.Name}, Genre: {book.Genre}, Price: {book.Price}, Review: {Review}");
        }
    }

    // Клас, що представляє користувача бібліотеки
    class LibraryUser
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public LibraryUser(string name)
        {
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
            Console.WriteLine($"{Name} borrowed the book: {book.Title}");
        }

        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(book);
            Console.WriteLine($"{Name} returned the book: {book.Title}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 5
         
            Author author1 = new Author("Author 1");
            Author author2 = new Author("Author 2");

            // Створення об'єктів книг
            Book book1 = new Book("Book 1", author1, "Genre 1", 10.99m);
            Book book2 = new Book("Book 2", author2, "Genre 2", 15.99m);

            // Додавання обкладинки та рецензії до книг
            Book decoratedBook1 = new CoverDecorator(book1, "Hardcover");
            Book decoratedBook2 = new ReviewDecorator(book2, "Great book!");

           
            decoratedBook1.Display();
            decoratedBook2.Display();

         
            LibraryUser user1 = new LibraryUser("User 1");

          
            user1.BorrowBook(book1);
            user1.ReturnBook(book1);

            // Task 1

            //List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            //var evenNumbers = numbers.FindAll(n => n % 2 == 0);

            //Console.WriteLine("evenNumbers");

            //foreach ( var number in evenNumbers )
            //{
            //    Console.WriteLine(number);
            //}


            // Task 2

            //double[] numbers = { 2.12, 1.10, 3.4, 12.14, 7.8 };

            //double average = numbers.Average();

            //Console.WriteLine("Array numbers" + string.Join(", ", numbers));
            //Console.WriteLine("Aversge number" + average);


            // Task 3

            //string[] Array = { "Cat", "Dog", "Giparde", "Puma", "Hachhog" };



            //string longestString = Array.OrderBy(s => s.Length).LastOrDefault();

            //Console.WriteLine($"The most longest line {longestString}");

            //Task 4

            //    var people = new List<Person>
            //{
            //    new Person { Name = "Max", Age = 30 },
            //    new Person { Name = "Bogdan", Age = 27 },
            //    new Person { Name = "Artur", Age = 16 },
            //    new Person { Name = "Denys", Age = 25 },
            //    new Person { Name = "Arsen", Age = 31 }
            //};

            //    var youngPeople = people.Where(person => person.Age < 30).ToList();

            //    // Виведення результатів
            //    Console.WriteLine("Persons under 30 years of age:");
            //    foreach (var person in youngPeople)
            //    {
            //        Console.WriteLine($"Name: {person.Name}, Age: {person.Age} years");

            //    }
            //}



        }
    }
}

                 
    

