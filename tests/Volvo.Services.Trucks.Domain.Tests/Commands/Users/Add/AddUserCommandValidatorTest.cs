using Volvo.Services.Trucks.Domain.Commands.Users.Add;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Users.Add
{
    public class AddUserCommandValidatorTest
    {
        private readonly AddUserCommandValidator _sut;

        public AddUserCommandValidatorTest()
        {
            _sut = new AddUserCommandValidator();
        }

        [Fact]
        public void MustCreateValidAddUserCommandValidator()
        {
            var command = new AddUserCommand
            {
                Email = "test@test.com",
                Name = "user",
                Password = "password"
            };

            var result = _sut.Validate(command);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("", "user", "password")]
        [InlineData(null, "user", "password")]
        [InlineData("test@test.com", "", "password")]
        [InlineData("test@test.com", null, "password")]
        [InlineData("test@test.com", "user", "")]
        [InlineData("test@test.com", "user", null)]

        public void MustCreateInvalidAddUserCommandValidator(
            string email,
            string name,
            string password
        )
        {
            var command = new AddUserCommand
            {
                Email = email,
                Name = name,
                Password = password
            };

            var result = _sut.Validate(command);

            Assert.False(result.IsValid);
        }
    }
}