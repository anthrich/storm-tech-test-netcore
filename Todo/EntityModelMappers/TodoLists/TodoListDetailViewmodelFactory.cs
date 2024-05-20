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
            TodoListDetailViewmodel.Ordering order = TodoListDetailViewmodel.Ordering.Asc,
            TodoListDetailViewmodel.SortProperty orderBy = TodoListDetailViewmodel.SortProperty.Importance)
        {
            var items = todoList.Items
                .Select(TodoItemSummaryViewmodelFactory.Create);
            if (hideCompleted) items = items.Where(i => !i.IsDone);
            return new TodoListDetailViewmodel(
                todoList.TodoListId, todoList.Title, items.ToList(), order: order, orderBy: orderBy);
        }
    }
}