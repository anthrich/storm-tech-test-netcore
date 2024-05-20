using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
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
        public SortProperty OrderBy { get; }
        public Ordering Order { get; }

        public TodoListDetailViewmodel(
            int todoListId,
            string title,
            ICollection<TodoItemSummaryViewmodel> items,
            bool hideCompleted = false,
            SortProperty orderBy = SortProperty.Importance,
            Ordering order = Ordering.Asc)
        {
            Items = items;
            TodoListId = todoListId;
            Title = title;
            HideCompleted = hideCompleted;
            OrderBy = orderBy;
            Order = order;
        }
        
        public enum SortProperty
        {
            Importance,
            Rank
        }
        
        public enum Ordering
        {
            Asc,
            Desc,
        }
    }
}