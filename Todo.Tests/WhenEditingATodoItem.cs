using System.Linq;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Xunit;

namespace Todo.Tests
{
    public class WhenEditingATodoItem
    {
        [Fact]
        public void The_rank_is_updated()
        {
            // Arrange
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                .WithItem("bread", Importance.High)
                .Build();
            var item = todoList.Items.First();
            var editFields = TodoItemEditFieldsFactory.Create(item);
            editFields.Rank = 11;

            // Act
            TodoItemEditFieldsFactory.Update(editFields, item);

            // Assert
            Assert.Equal(11, item.Rank);
        }
    }
}