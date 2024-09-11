using System;
using BookAPI.Models;

namespace BookAPI.Services;
public class BookService
{
    static List<Book> Books { get; }
    static int nextId = 3;
    static BookService()
    {
        Books = new List<Book>
        {
            new Book{Id = 1, Name = "Kitap1", Author = "Yazar1", PageCount = 100},
            new Book{Id = 2, Name = "Kitap2", Author = "Yazar2", PageCount = 200},
        };
    }

    public static List<Book> GetBooks() => Books;
    public static Book? GetBook(int id) => Books.FirstOrDefault(x => x.Id == id);

    public static void AddBook(Book book)
    {
        book.Id = nextId++;
        Books.Add(book);
    }
    public static void DeleteBook(int id)
    {
        var book = GetBook(id);
        if (book is null)
        {
            return;
        }

        Books.Remove(book);
    }

    public static void UpdateBook(Book book)
    {
        var index = Books.FindIndex(b => b.Id == book.Id);
        if (index == -1)
        {
            return;
        }
        Books[index] = book;
    }
}
