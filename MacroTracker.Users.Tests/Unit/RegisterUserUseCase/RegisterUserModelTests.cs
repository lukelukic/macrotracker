using FluentAssertions;
using MacroTracker.Users.Application.UseCases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace MacroTracker.Users.Tests.Unit.RegisterUserUseCaseTest
{
    public class RegisterUserUseCaseTests
    {
        [Fact]
        public void ErrorOnEmptyEmailAddress()
        {
            var model = new RegisterUserUseCase();
            HasValidationError(model, "Email address is required.").Should().BeTrue();
        }

        [Fact]
        public void ErrorOnInvalidEmailFormat()
        {
            var model = new RegisterUserUseCase
            {
                Email = "123"
            };
            HasValidationError(model, "Invalid email address format.").Should().BeTrue();
        }

        [Fact]
        public void ErrorOnEmptyUsername()
        {
            var model = new RegisterUserUseCase();
            HasValidationError(model, "Username is required.").Should().BeTrue();
        }

        [Fact]
        public void ErrorOnInvalidUsername()
        {
            var model = new RegisterUserUseCase
            {
                Username = "123"
            };
            HasValidationError(model, "Invalid username format.").Should().BeTrue();
        }

        [Fact]
        public void ErrorOnEmptyFirstName()
        {
            var model = new RegisterUserUseCase();
            HasValidationError(model, "First name is required.").Should().BeTrue();
        }

        [Fact]
        public void ErrorOnInvalidFirstName()
        {
            var model = new RegisterUserUseCase()
            {
                FirstName = "pera"
            };
            HasValidationError(model, "Invalid frist name format. Example: Pera").Should().BeTrue();
        }

        [Fact]
        public void ErrorOnInvalidPassword()
        {
            var model = new RegisterUserUseCase()
            {
                Password = "1"
            };
            HasValidationError(model, "Password must be at least 8 characters long.").Should().BeTrue();
        }

        private bool HasValidationError(RegisterUserUseCase model, string error)
        {
            var context = new ValidationContext(model);
            var validationResult = new List<ValidationResult>();
            var result = Validator.TryValidateObject(model, context, validationResult, true);

            return validationResult.Where(r => r.ErrorMessage == error).Any();
        }
    }
}