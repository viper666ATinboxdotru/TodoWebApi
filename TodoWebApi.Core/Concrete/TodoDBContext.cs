﻿using System;
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
        public TodoDBContext() : base(@"Data Source=tcp:adtodolistwebapinewdbsrv.database.windows.net,1433;Initial Catalog=adtodolistwebapinewdb;User ID=adodalev@adtodolistwebapinewdbsrv;Password=Demigod666")
        {   
            Database.SetInitializer(new TodoDBInitializer());
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}