using System.ComponentModel.DataAnnotations;

namespace TodoTaskService.DTOs
{
    public class TodoTaskReadDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }
    }
}
