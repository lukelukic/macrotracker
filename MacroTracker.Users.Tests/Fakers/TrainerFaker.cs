using Bogus;
using MacroTracker.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MacroTracker.Users.Tests.Fakers
{
    public class TrainerFaker : AbstractFaker<Trainer>
    {
        protected override Faker<Trainer> Faker =>
            new Faker<Trainer>()
            .RuleFor(r => r.Email, f => f.Person.Email)
            .RuleFor(r => r.FirstName, f => f.Person.FirstName)
            .RuleFor(r => r.LastName, f => f.Person.LastName)
            .RuleFor(r => r.Username, f => f.Person.UserName)
            .RuleFor(r => r.Password, f => f.Internet.Password());
    }
}
