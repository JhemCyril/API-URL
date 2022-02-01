using Project.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Data
{
    public class ProjectListContext : IdentityDbContext<ApplicationUser>
    {
        public ProjectListContext(DbContextOptions<ProjectListContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }
    }
}