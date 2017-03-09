using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoWebApi.Core.Concrete.DBInitializer;
using TodoWebApi.Core.Entities;

namespace TodoWebApi.Core.Concrete
{
    public class TodoDBContext : DbContext
    {
        //public TodoDBContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\azure\TodoWebApi\TodoWebApi\App_Data\TodoDB.mdf;Integrated Security=True")
        public TodoDBContext() : base(@"Data Source=adtodo.database.windows.net;Initial Catalog=TodoDB;Integrated Security=False;User ID=adodalev;Password=Demigod666;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {   
            Database.SetInitializer(new TodoDBInitializer());
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}