using System.Collections.Generic;
using Demo1.Api.Data.Entities;

namespace Demo1.TestApi.MockData;
public class TodoMockData
{
    public static List<Todo> GetTodos()
    {
        return new List<Todo>{
             new Todo{
                 Id = 1,
                 ItemName = "Need To Go Shopping",
                 IsCompleted = true
             },
             new Todo{
                 Id = 2,
                 ItemName = "Cook Food",
                 IsCompleted = true
             },
             new Todo{
                 Id = 3,
                 ItemName = "Play Games",
                 IsCompleted = false
             }
         };
    }

    public static List<Todo> GetEmptyTodos()
    {
        return new List<Todo>();
    }

    public static Todo NewTodo()
    {
        return new Todo
        {
            Id = 0,
            ItemName = "wash cloths",
            IsCompleted = false
        };
    }
}