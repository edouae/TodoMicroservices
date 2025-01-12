using System.ComponentModel.DataAnnotations;

namespace TodoTaskService.DTOs
{
    public class TodoTaskCreateDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
