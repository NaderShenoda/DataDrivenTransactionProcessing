using AdminPortal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AdminPortal.Api
{
    public partial class DataContext : DbContext
    {
        public DataContext() : base() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<DataDefinition> DataDefinitions { get; set; }

        public virtual DbSet<DataFieldDefinition> DataFieldDefinitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
            }
        }
    }
}