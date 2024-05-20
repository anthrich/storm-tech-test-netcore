using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Xunit;

namespace Todo.Tests
{
    public class WhenCreatingTodoListDetailViewModel
    {
        [Fact]
        public void It_includes_item_ranks()
        {
            // Arrange
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .WithItem("wash car", Importance.Low)
                .WithItem("rubbish", Importance.Medium)
                .Build();

            // Act
            var viewModel = TodoListDetailViewmodelFactory.Create(todoList);

            // Assert
            Assert.Equal(new List<int> { 1, 2, 3 }, viewModel.Items.Select(i => i.Rank));
        }
    }
}