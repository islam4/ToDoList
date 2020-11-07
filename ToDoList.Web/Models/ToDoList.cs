using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoList.Web.Models
{
    [Table("ToDoList")]
    public class ToDoList
    {
        [Key]
        public int ToDoId { get; set; }
        public string ToDoTitle { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}