using ToDoMVC.Models;

namespace ToDoMVC.Interfaces
{
    public interface ITaskToDoRepository
    {
        IEnumerable<TaskToDo> GetAll();
        TaskToDo GetById(int id);
        void Create(TaskToDo task);
        void Update(TaskToDo task);
        void Delete(TaskToDo task);
    }
}
