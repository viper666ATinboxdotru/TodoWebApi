using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TodoWebApi.Core.Concrete;
using TodoWebApi.Core.Entities;
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

        public async Task<IHttpActionResult> Get(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                var item = await ctx.TodoItems.FirstOrDefaultAsync(i => i.Id == id);
                if (item == null)
                    return NotFound();
                var data = new ItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsComplete = item.IsComplete
                };
                return Ok(data);
            }
        }

        public async Task<IHttpActionResult> Put(CreateItemViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var ctx = new TodoDBContext())
            {
                var item = new TodoItem() {
                    Name = model.Name,
                    IsComplete = false,
                    DatePosted = DateTime.Now

                };
                ctx.TodoItems.Add(item);
                await ctx.SaveChangesAsync();

                var data = new ItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsComplete = item.IsComplete
                };

                return Created(new Uri(Request.RequestUri + "api/todo" + data.Id), data);
            }
        }

        public async Task<IHttpActionResult> Post(EditItemViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (var ctx = new TodoDBContext())
            {
                var item = new TodoItem()
                {
                    Id = model.Id.Value,
                    Name = model.Name,
                    IsComplete = model.IsComplete,
                    DatePosted = DateTime.Now
                    
                };

                ctx.TodoItems.Attach(item);
                ctx.Entry(item).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var ctx = new TodoDBContext())
            {
                var item = await ctx.TodoItems.FirstOrDefaultAsync(i => i.Id == id);
                if (item == null)
                    return NotFound();

                ctx.TodoItems.Remove(item);
                await ctx.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
