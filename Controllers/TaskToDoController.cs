using Microsoft.AspNetCore.Mvc;
using ToDoMVC.Interfaces;
using ToDoMVC.Models;

namespace ToDoMVC.Controllers
{
    public class TaskToDoController : Controller
    {
        private readonly ITaskToDoRepository _taskToDoRepository;

        public TaskToDoController(ITaskToDoRepository taskToDoRepository)
        {
            _taskToDoRepository = taskToDoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskToDo task)
        {
            if(ModelState.IsValid)
            {
                _taskToDoRepository.Create(task);
                return RedirectToAction("Index", "Home");
            }
            return PartialView("_NotFound");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var task = _taskToDoRepository.GetById(id);

            if(task == null)
            {
                return PartialView("_NotFound");
            }

            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _taskToDoRepository.GetById(id);

            if(task == null) 
            {
                return PartialView("_NotFound");
            }

            return View(task);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult Edit(TaskToDo task, int id)
        {
            if(ModelState.IsValid)
            {
                if(id == task.Id)
                {
                    _taskToDoRepository.Update(task);

                    return RedirectToAction("Index", "Home");
                }
            }
            return PartialView("_NotFound");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _taskToDoRepository.GetById(id);
            if(task == null)
            {
                return PartialView("_NotFound");
            }

            return View(task);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(TaskToDo task, int id) 
        {
            if(id != task.Id)
            {
                return PartialView("_NotFound");
            }

            _taskToDoRepository.Delete(task);

            return RedirectToAction("Index", "Home");
        }
    }
}
