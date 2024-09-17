namespace todoList.DTOs.Request
{
    public class TaskRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskStatus status { get; set; }
    }
}
