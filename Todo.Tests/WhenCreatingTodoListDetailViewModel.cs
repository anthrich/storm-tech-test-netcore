using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoLists;
using Todo.Models.TodoLists;
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
            viewModel.Items.Select(i => i.Rank).Should().BeEquivalentTo(new List<int> { 1, 2, 3 });
        }
        
        [Theory]
        [InlineData(TodoListDetailViewmodel.Ordering.Asc)]
        [InlineData(TodoListDetailViewmodel.Ordering.Desc)]
        public void It_sets_sort_direction(TodoListDetailViewmodel.Ordering ordering)
        {
            // Arrange
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping").Build();

            // Act
            var viewModel = TodoListDetailViewmodelFactory.Create(todoList, order: ordering);

            // Assert
            Assert.Equal(viewModel.Order, ordering);
        }
        
        [Theory]
        [InlineData(TodoListDetailViewmodel.SortProperty.Importance)]
        [InlineData(TodoListDetailViewmodel.SortProperty.Rank)]
        public void It_sets_sort_property(TodoListDetailViewmodel.SortProperty sortProperty)
        {
            // Arrange
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping").Build();

            // Act
            var viewModel = TodoListDetailViewmodelFactory.Create(todoList, orderBy: sortProperty);

            // Assert
            Assert.Equal(viewModel.OrderBy, sortProperty);
        }
    }
}