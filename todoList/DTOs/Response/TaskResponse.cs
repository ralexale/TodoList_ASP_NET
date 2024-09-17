using todoList.utils;

namespace todoList.DTOs.Response
{
    public class TaskResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
