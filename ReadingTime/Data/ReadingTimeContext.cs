using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadingTime.Models;

namespace ReadingTime.Data
{
    public class ReadingTimeContext : DbContext
    {
        public ReadingTimeContext (DbContextOptions<ReadingTimeContext> options)
            : base(options)
        {
        }

        public DbSet<ReadingTime.Models.User> User { get; set; }

        public DbSet<ReadingTime.Models.Book> Book { get; set; }

        public DbSet<ReadingTime.Models.MyGoalList> MyGoalList { get; set; }
    }
}
