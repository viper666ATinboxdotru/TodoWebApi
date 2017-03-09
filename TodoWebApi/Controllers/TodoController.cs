using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TodoWebApi.Core.Concrete;
using TodoWebApi.ViewModels;

namespace TodoWebApi.Controllers
{
    public class TodoController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            using (TodoDBContext ctx = new TodoDBContext())
            {
                var items = await ctx.TodoItems.Select(i => new ItemViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsComplete = i.IsComplete                    
                }).ToListAsync();
                return Ok(items);
            }
        }

        //TodoItem[] todoItems = new TodoItem[]
        //   {
        //        new TodoItem { Id = 1, Name="Item1" , IsComplete=false },
        //        new TodoItem { Id = 2, Name="Item2" , IsComplete=false },
        //        new TodoItem { Id = 3, Name="Item3" , IsComplete=false },
        //        new TodoItem { Id = 4, Name="Item4" , IsComplete=false },
        //        new TodoItem { Id = 5, Name="Item5" , IsComplete=false },
        //   };

        //public IEnumerable<TodoItem> GetAll()
        //{
        //    return todoItems;
        //}

        //public IHttpActionResult GetTodoItem(int id)
        //{
        //    var todoItem = todoItems.FirstOrDefault(t => t.Id == id);
        //    if (todoItem == null)
        //        return NotFound();
        //    return Ok(todoItem);
        //}
    }
}
