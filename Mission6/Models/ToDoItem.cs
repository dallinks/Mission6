using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class ToDoItem
    {
        [Key]
        [Required]
        public int ToDoItemId { get; set; }
        [Required]
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public int CategoryId { get; set; }
        public Category Category {get; set;}
        public bool Completed { get; set; }
                
    }
}
