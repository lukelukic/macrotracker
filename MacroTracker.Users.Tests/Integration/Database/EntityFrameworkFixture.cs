using MacroTracker.Users.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacroTracker.Users.Tests.Integration.Database
{
    public class EntityFrameworkFixture : IDisposable
    {
        public UsersDbContext Context { get; }

        public EntityFrameworkFixture()
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlite("Data Source=:memory:");
            Context = new UsersDbContext(optionsBuilder.Options);
            Context.Database.OpenConnection();
            Context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Database.CloseConnection();
        }
    }
}
