using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_Task.Shared;

namespace My_Task.Server.Data
{
    public class My_TaskServerContext : DbContext
    {
        public My_TaskServerContext (DbContextOptions<My_TaskServerContext> options)
            : base(options)
        {
        }

        public DbSet<My_Task.Shared.TaskItem> TaskItem { get; set; } = default!;
    }
}
