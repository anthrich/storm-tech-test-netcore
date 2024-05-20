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
        public SortProperty SortBy { get; }
        public SortDirection OrderBy { get; }

        public TodoListDetailViewmodel(
            int todoListId,
            string title,
            ICollection<TodoItemSummaryViewmodel> items,
            bool hideCompleted = false,
            SortDirection orderBy = SortDirection.Asc)
        {
            Items = items;
            TodoListId = todoListId;
            Title = title;
            HideCompleted = hideCompleted;
            OrderBy = orderBy;
        }
        
        public enum SortProperty
        {
            Importance,
            Rank
        }
        
        public enum SortDirection
        {
            Asc,
            Desc,
        }
    }
}