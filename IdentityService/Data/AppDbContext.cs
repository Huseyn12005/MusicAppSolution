﻿using IdentityService.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}