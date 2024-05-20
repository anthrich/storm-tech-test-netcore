using System.Collections.Generic;
using System.ComponentModel;
using Todo.Models.TodoItems;

namespace Todo.Models.TodoLists
{
    public class TodoListDetailViewmodel
    {
        public int TodoListId { get; }
        public string Title { get; }
        public ICollection<TodoItemSummaryViewmodel> Items { get; }
        [DisplayName("Hide Completed?")]
        public bool HideCompleted { get; }

        public TodoListDetailViewmodel(
            int todoListId, string title, ICollection<TodoItemSummaryViewmodel> items, bool hideCompleted = false)
        {
            Items = items;
            TodoListId = todoListId;
            Title = title;
            HideCompleted = hideCompleted;
        }
    }
}