using System.Threading.Tasks;
using Demo1.Api.Controllers;
using Demo1.Api.Services;
using Demo1.TestApi.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Demo1.TestApi.System.Controllers;

public class TestController
{
    [Fact]
    public async Task GetAllAsync_ShouldReturn200Status()
    {
        /// Arrange
        var todoService = new Mock<ITodoService>();
        todoService.Setup(_ => _.GetAllAsync()).ReturnsAsync(TodoMockData.GetTodos());
        var sut = new TodoController(todoService.Object);

        /// Act
        var result = (OkObjectResult)await sut.GetAllAsync();


        // /// Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturn204NoContentStatus()
    {
        /// Arrange
        var todoService = new Mock<ITodoService>();
        todoService.Setup(_ => _.GetAllAsync()).ReturnsAsync(TodoMockData.GetEmptyTodos());
        var sut = new TodoController(todoService.Object);

        /// Act
        var result = (NoContentResult)await sut.GetAllAsync();


        /// Assert
        result.StatusCode.Should().Be(204);
        todoService.Verify(_ => _.GetAllAsync(), Times.Exactly(1));
    }

    [Fact]
    public async Task SaveAsync_ShouldCall_ITodoService_SaveAsync_AtleastOnce()
    {
        /// Arrange
        var todoService = new Mock<ITodoService>();
        var newTodo = TodoMockData.NewTodo();
        var sut = new TodoController(todoService.Object);

        /// Act
        var result = await sut.SaveAsync(newTodo);

        /// Assert
        todoService.Verify(_ => _.SaveAsync(newTodo),Times.Exactly(1));
    }
}