using Dept_ItemsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dept_ItemsApp.Context
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() : base("Model1")
        {

        }
        public DbSet<dept2> dept2s { get; set; }
        public DbSet<items2> items2s { get; set; }
    }
}