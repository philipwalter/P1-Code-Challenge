using System;

namespace DataModel
{
    public class ToDoItem
    {

        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public System.Nullable<DateTime> DueDate { get; set; }

    }
}
