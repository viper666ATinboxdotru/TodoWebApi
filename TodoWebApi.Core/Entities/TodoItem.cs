using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoWebApi.Core.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DatePosted { get; set; }
    }
}