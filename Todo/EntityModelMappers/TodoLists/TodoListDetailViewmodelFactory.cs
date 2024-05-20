using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListDetailViewmodelFactory
    {
        public static TodoListDetailViewmodel Create(
            TodoList todoList,
            bool hideCompleted = false,
            TodoListDetailViewmodel.SortDirection sortDirection = TodoListDetailViewmodel.SortDirection.Asc)
        {
            var items = todoList.Items
                .Select(TodoItemSummaryViewmodelFactory.Create);
            if (hideCompleted) items = items.Where(i => !i.IsDone);
            if (sortDirection == TodoListDetailViewmodel.SortDirection.Asc)
            {
                items = items.OrderBy(i => i.Importance);
            }
            return new TodoListDetailViewmodel(
                todoList.TodoListId, todoList.Title, items.ToList(), orderBy: sortDirection);
        }
    }
}