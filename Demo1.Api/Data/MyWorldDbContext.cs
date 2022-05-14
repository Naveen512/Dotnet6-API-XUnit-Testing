using Demo1.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Api.Data;


public class MyWorldDbContext : DbContext
{
    public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
    {
 
    }
    public DbSet<Todo> Todo { get; set; }
}