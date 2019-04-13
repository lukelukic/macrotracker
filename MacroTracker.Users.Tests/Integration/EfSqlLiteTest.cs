using MacroTracker.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacroTracker.Users.Tests.Unit
{
    public class EfSqlLiteTest
    {
        protected UsersDbContext CreateDbContext()
        {
            var builder = new DbContextOptionsBuilder<UsersDbContext>();
            builder.UseLazyLoadingProxies().UseSqlite("DataSource=:memory:");

            var options = builder.Options;

            return new UsersDbContext(options);
        }
    }
}
