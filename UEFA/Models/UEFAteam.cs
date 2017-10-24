using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UEFA.Models
{

    public class UEFAContext : DbContext
    {
        public UEFAContext(DbContextOptions<UEFAContext> options)
            : base(options)
        {
        }
        public DbSet<UEFAteam> UEFAteams { get; set; }
    }
    public class UEFAteam
    {
        public long id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public bool neededQualification { get; set; }
        public string Manager { get; set; }
        public string currentRecord { get; set; }
        public string currentPhase { get; set; }
        public bool previousWinner { get; set; }

    }
}
