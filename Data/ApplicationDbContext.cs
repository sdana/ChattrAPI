using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChattrApi.Models;

namespace ChattrApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Chatroom> Chatroom { get; set; }
        public DbSet<ChatAllowedUsers> ChatAllowedUsers { get; set; }
        public DbSet<FavoritePeople> FavoritePeople { get; set; }
        public DbSet<Messages> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Chatroom general = new Chatroom
            {
                ChatroomId = 1,
                Title = "General"
            };
            modelBuilder.Entity<Chatroom>().HasData(general);

            Chatroom introductions = new Chatroom
            {
                ChatroomId = 2,
                Title = "Introductions"
            };
            modelBuilder.Entity<Chatroom>().HasData(introductions);

            Chatroom chat3 = new Chatroom
            {
                ChatroomId = 3,
                Title = "Chat 3"
            };
            modelBuilder.Entity<Chatroom>().HasData(chat3);
        }
    }

}