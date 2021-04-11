﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zad3.Model;

namespace zad3.Data
{
    public class BuzzFizzContext : DbContext
    {
        public BuzzFizzContext(DbContextOptions options) : base(options) { }
        public DbSet<BuzzFizz> BuzzFizz { get; set; }
    }
}