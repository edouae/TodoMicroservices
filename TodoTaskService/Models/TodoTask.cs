using System.ComponentModel.DataAnnotations;

namespace TodoTaskService.Models
{
    public class TodoTask
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
