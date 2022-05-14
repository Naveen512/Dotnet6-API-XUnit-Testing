using Demo1.Api.Data;
using Demo1.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;



namespace Demo1.Api.Services;

public class TodoService : ITodoService
{
    private readonly MyWorldDbContext _context;
    public TodoService(MyWorldDbContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await _context.Todo.ToListAsync();
    }

    public async Task SaveAsync(Todo newTodo)
    {
        _context.Todo.Add(newTodo);
        await _context.SaveChangesAsync();
    }
}