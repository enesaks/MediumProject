using System;

namespace IdentityWebApi.Model.Entities;

public class Book
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }

}
