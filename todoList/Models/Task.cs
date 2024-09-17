using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using todoList.utils;

namespace todoList.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title {  get; set; }

        public string Description { get; set; }

        public TodoTaskStatus Status { get; set; }
    }
}
