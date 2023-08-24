using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoMVC.Interfaces;
using ToDoMVC.Models;

namespace ToDoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskToDoRepository _taskToDoRepository;

        public HomeController(ITaskToDoRepository taskToDoRepository)
        {
            _taskToDoRepository = taskToDoRepository;
        }

        public ActionResult<IEnumerable<TaskToDo>> Index()
        {
            var tasks = _taskToDoRepository.GetAll();

            return View(tasks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}