using System.Collections.Generic;
using System.Linq;
using DataModel;

namespace DataProvider
{
    public class Priority1ToDoRepository : IPriority1Repository
    {

        private readonly P1DbContext _context = new P1DbContext();

        public void AddTodo(ToDoItem toDo)
        {
            _context.ToDoItems.Add(toDo);
            _context.SaveChanges();
        }

        public void DeleteTodo(int id)
        {
            ToDoItem item = GetToDo(id);
            _context.ToDoItems.Remove(item);
            _context.SaveChanges();
        }

        public List<ToDoItem> GetAllTodos()
        {
            return _context.ToDoItems.ToList();
        }

        public List<ToDoItem> GetPendingTodos()
        {
            List<ToDoItem> results = new List<ToDoItem>();

            var tmpToDos = _context.ToDoItems.Where(t => t.IsComplete == false);
            results = tmpToDos.ToList();

            return results;
        }

        public List<ToDoItem> GetCompleteTodos()
        {
            List<ToDoItem> results = new List<ToDoItem>();

            var tmpToDos = _context.ToDoItems.Where(t => t.IsComplete == true);
            results = tmpToDos.ToList();

            return results;
        }

        public void MarkComplete(int id)
        {
            _context.ToDoItems.Find(id).IsComplete = true;
            _context.SaveChanges();
        }

        public ToDoItem GetToDo(int id)
        {
            ToDoItem item = _context.ToDoItems.Find(id);
            return item;
        }

    }
}
