using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data
{
    public class MainContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        { }

    }
}
