using System;

namespace BookAPI.Models;

public class Book
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }

}
