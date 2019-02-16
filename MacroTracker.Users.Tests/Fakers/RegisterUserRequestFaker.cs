using Bogus;
using MacroTracker.Users.Application.UseCases;

namespace MacroTracker.Users.Tests.Fakers
{
    public class RegisterUserRequestFaker : AbstractFaker<RegisterUserUseCase>
    {
        protected override Faker<RegisterUserUseCase> Faker =>
            new Faker<RegisterUserUseCase>()
            .RuleFor(r => r.Email, f => f.Person.Email)
            .RuleFor(r => r.FirstName, f => f.Person.FirstName)
            .RuleFor(r => r.LastName, f => f.Person.LastName)
            .RuleFor(r => r.Username, f => f.Person.UserName)
            .RuleFor(r => r.Password, f => f.Internet.Password());
    }
}