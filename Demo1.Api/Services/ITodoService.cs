
using Demo1.Api.Data.Entities;

namespace Demo1.Api.Services;

public interface ITodoService
{
    Task<List<Todo>> GetAllAsync();
    Task SaveAsync(Todo newTodo);
}