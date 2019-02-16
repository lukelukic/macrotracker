using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace MacroTracker.Users.Tests.Fakers
{
    public abstract class AbstractFaker<T> where T : class
    {
        public T GetOne => Faker.Generate(1).First();

        public IEnumerable<T> Get(int count) => Faker.Generate(count);

        protected abstract Faker<T> Faker { get; }
    }
}