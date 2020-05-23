using System.Collections.Generic;
using DataModel;

namespace DataProvider
{
    public interface IPriority1Repository
    {

        void AddTodo(ToDoItem toDo);
        void DeleteTodo(int id);
        ToDoItem GetToDo(int id);
        List<ToDoItem> GetAllTodos();
        List<ToDoItem> GetPendingTodos();
        List<ToDoItem> GetCompleteTodos();
        void MarkComplete(int id);

    }
}
