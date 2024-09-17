using Microsoft.EntityFrameworkCore;

namespace todoList.Models
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options) 
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
