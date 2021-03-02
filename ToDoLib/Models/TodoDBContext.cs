using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoLib.Models {
    public class TodoDBContext : DbContext {

        public DbSet<Todo> Todos {  get; set; }
        public DbSet<Category> categories { get; set; }
        public TodoDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if(!builder.IsConfigured) {
                var connStr = "server=localhost\\sqlexpress;" +
                                "database=TodoDb1;" +
                               "trusted_connection=true;";
                builder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) { } 
        
       
    }
}
