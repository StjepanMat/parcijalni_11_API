﻿using System.ComponentModel.DataAnnotations;

namespace Ispit.Data.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;

    }
}
