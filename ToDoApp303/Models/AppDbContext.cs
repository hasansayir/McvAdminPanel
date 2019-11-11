using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        //Not : ilerde kendi ApplicationUser'imizi oluşturacağız

        public AppDbContext():base("DefCon")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        //Veri tabanı yoksa oluşturur
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        
    }
}