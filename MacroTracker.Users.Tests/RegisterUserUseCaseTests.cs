using EventBus;
using MacroTracker.Users.Application.Exceptions;
using MacroTracker.Users.Application.Repositories;
using MacroTracker.Users.Application.UseCases;
using MacroTracker.Users.Domain;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading;
using Xunit;

namespace MacroTracker.Users.Tests
{
    public class RegisterUserUseCaseTests
    {
        private readonly IUserRepository _repo;

        public RegisterUserUseCaseTests()
        {
            var mock = new Mock<IUserRepository>();

            mock.Setup(ur => ur.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(new User[]
            {
                new User(),
                new User(),
                new User()
            });

            _repo = mock.Object;
        }

        [Fact]
        public async System.Threading.Tasks.Task ThrowsExceptionWhenUserExists()
        {
            var useCase = new Mock<RegisterUserUseCase>().Object;
            var bus = new Mock<IEventBus>().Object;
            var handler = new RegisterUserHandler(bus, _repo);

            await Assert.ThrowsAsync<EntityAlreadyExists>(() => handler.Handle(useCase, new CancellationToken()));
        }
    }
}