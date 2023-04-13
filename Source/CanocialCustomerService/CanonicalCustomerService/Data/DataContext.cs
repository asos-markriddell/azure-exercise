﻿using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CanonicalCustomer> CanonicalCustomer { get; set; }
    }
}
