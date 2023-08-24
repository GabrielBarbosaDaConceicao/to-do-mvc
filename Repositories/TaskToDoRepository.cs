using ToDoMVC.Context;
using ToDoMVC.Interfaces;
using ToDoMVC.Models;

namespace ToDoMVC.Repositories
{
    public class TaskToDoRepository : ITaskToDoRepository
    {
        private readonly AppDbContext _context;
        public TaskToDoRepository(AppDbContext context) 
        { 
            _context = context;
        }

        public IEnumerable<TaskToDo> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public TaskToDo GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Create(TaskToDo task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void Update(TaskToDo task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

      
        public void Delete(TaskToDo task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }
    }
}
