using System;
using IdentityWebApi.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityWebApi.Model.Context;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {

    }
    public DbSet<Book> Books { get; set; }
}
