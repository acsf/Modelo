﻿using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=MySQL57;Port=8080;Database=modelo;" +
                    "Uid=root;Pwd=root");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UserMap().Configure);
        }
    }
}
