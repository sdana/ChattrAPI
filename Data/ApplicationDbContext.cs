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
    }
}