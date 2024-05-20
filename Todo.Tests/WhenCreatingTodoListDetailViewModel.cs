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
        private static TodoList TodoList
        {
            get
            {
                var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                    .WithItem("bread", Importance.High)
                    .WithItem("wash car", Importance.Low)
                    .WithItem("rubbish", Importance.Medium)
                    .Build();
                return todoList;
            }
        }

        [Fact]
        public void It_includes_item_ranks()
        {
            // Act
            var viewModel = TodoListDetailViewmodelFactory.Create(TodoList);

            // Assert
            viewModel.Items.Select(i => i.Rank).Should().BeEquivalentTo(new List<int> { 1, 2, 3 });
        }

        [Fact]
        public void It_orders_by_importance_ascending()
        {
            // Act
            var viewModel = TodoListDetailViewmodelFactory.Create(
                TodoList,
                order: TodoListDetailViewmodel.Ordering.Asc,
                orderBy: TodoListDetailViewmodel.SortProperty.Importance);

            // Assert
            var itemOrder = viewModel.GetItems().Select(i => i.Importance);
            itemOrder.Should().Equal(Importance.High, Importance.Medium, Importance.Low);
        }
        
        [Fact]
        public void It_orders_by_importance_descending()
        {
            // Act
            var viewModel = TodoListDetailViewmodelFactory.Create(
                TodoList,
                order: TodoListDetailViewmodel.Ordering.Desc,
                orderBy: TodoListDetailViewmodel.SortProperty.Importance);

            // Assert
            var itemOrder = viewModel.GetItems().Select(i => i.Importance);
            itemOrder.Should().Equal(Importance.Low, Importance.Medium, Importance.High);
        }
        
        [Fact]
        public void It_orders_by_rank_ascending()
        {
            // Act
            var viewModel = TodoListDetailViewmodelFactory.Create(
                TodoList,
                order: TodoListDetailViewmodel.Ordering.Asc,
                orderBy: TodoListDetailViewmodel.SortProperty.Rank);

            // Assert
            var itemOrder = viewModel.GetItems().Select(i => i.Rank);
            itemOrder.Should().Equal(1, 2, 3);
        }
        
        [Fact]
        public void It_orders_by_rank_descending()
        {
            // Act
            var viewModel = TodoListDetailViewmodelFactory.Create(
                TodoList,
                order: TodoListDetailViewmodel.Ordering.Desc,
                orderBy: TodoListDetailViewmodel.SortProperty.Rank);

            // Assert
            var itemOrder = viewModel.GetItems().Select(i => i.Rank);
            itemOrder.Should().Equal(3, 2, 1);
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