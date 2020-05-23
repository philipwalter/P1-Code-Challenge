using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataProvider;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {

        public IPriority1Repository TodoItems { get; set; }

        public HomeController(IPriority1Repository todoitems)
        {
            TodoItems = todoitems;
        }

        public IActionResult Index()
        {
            List<ToDoItem> items = TodoItems.GetPendingTodos();

            return View(items);
        }

        // POST Route for creating new ToDoItems
        [HttpPost]
        public IActionResult Index(string todoDescription)
        {

            string desc = todoDescription;
            DateTime d = DateTime.Now;

            ToDoItem item = new ToDoItem();
            item.DateCreated = d;
            item.Description = desc;

            TodoItems.AddTodo(item);

            List<ToDoItem> items = TodoItems.GetPendingTodos();

            return View(items);
        }

        // DELETE Route Index/delete/id
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            TodoItems.DeleteTodo(id);

            List<ToDoItem> items = TodoItems.GetPendingTodos();

            return RedirectToAction("Index", items);
        }

        // COMPLETE Route Index/complete/id
        [Route("complete/{id}")]
        public IActionResult Complete(int id)
        {
            TodoItems.MarkComplete(id);

            List<ToDoItem> items = TodoItems.GetPendingTodos();

            return RedirectToAction("Index", items);
        }

        public IActionResult Notes()
        {
            ViewData["Message"] = "I created this page to share a few additional thoughts about this exercise.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
