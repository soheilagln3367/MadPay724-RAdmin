using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.DatabaseContext
{
    //ConnectionString
    class MadPayDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-C0S592B\SQLEXPRESS;Initial Catalog=MadPay724db;Integrated Security=True;MultipleActiveResultSets=True;");
        }
    }
}
