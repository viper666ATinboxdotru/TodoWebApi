using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Core.Concrete;
using TodoWebApi.Core.Entities;

namespace TodoWebApi.Core.Concrete.DBInitializer
{
    class TodoDBInitializer : DropCreateDatabaseAlways<TodoDBContext>
    {
        protected override void Seed(TodoDBContext context)
        {
            TodoItem[] todoItems = new TodoItem[]
               {
                new TodoItem { Id = 1, Name="Item1" , IsComplete=false, DatePosted = DateTime.Now },
                new TodoItem { Id = 2, Name="Item2" , IsComplete=false, DatePosted = DateTime.Now },
                new TodoItem { Id = 3, Name="Item3" , IsComplete=false, DatePosted = DateTime.Now },
                new TodoItem { Id = 4, Name="Item4" , IsComplete=false, DatePosted = DateTime.Now },
                new TodoItem { Id = 5, Name="Item5" , IsComplete=false, DatePosted = DateTime.Now },
              };

            context.TodoItems.AddRange(todoItems);
            base.Seed(context);
        }
    }
}
