using Microsoft.EntityFrameworkCore;
using todoList.DTOs.Request;
using todoList.DTOs.Response;
using todoList.Models;


namespace todoList.Services
{
    public class TaskService : ITaskService
    {

        private TodoContext _context;

        public TaskService(TodoContext context)
        {
            _context = context;
        }


        public async Task<TaskResponse> Create(TaskRequest taskRequest)
        {

            var task = new Models.Task()
            {
                Title = taskRequest.Title,
                Description = taskRequest.Description,
                Status = "created"
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            var taskResponse = new TaskResponse()
            {
                Title = task.Title,
                Description = task.Description,
                Status =  task.Status,
                Id = task.Id
            };

            return taskResponse;
        }

        public async Task<bool> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null) return false;

            task.Status = "closed";

            await _context.SaveChangesAsync();


            return true;
        }

        public async Task<IEnumerable<TaskResponse>> GetAll()
        {
            var tasks = await _context.Tasks.Select(t => new TaskResponse
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
            }).ToListAsync();
            return tasks;
        }

        public async Task<TaskResponse?> GetById(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null) return null;

            var taskResponse = new TaskResponse
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Id = task.Id
            };

            return taskResponse;
        }

        public async Task<TaskResponse?> Update(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null) return null;

        
            task.Status = "completed";
    

            await _context.SaveChangesAsync();

            var taskReponse = new TaskResponse
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Id = task.Id
            };

            return taskReponse;
        }
    }
}
