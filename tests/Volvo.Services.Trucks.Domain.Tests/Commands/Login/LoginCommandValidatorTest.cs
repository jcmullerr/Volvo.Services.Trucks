using Volvo.Services.Trucks.Domain.Commands.Login;
using Xunit;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Login
{
    public class LoginCommandValidatorTest
    {
        //System under test
        private readonly LoginCommandValidator _sut;

        public LoginCommandValidatorTest()
        {
            _sut = new LoginCommandValidator();
        }

        [Fact]
        public void MustCreateValidLoginCommand()
        {
            var command = new LoginCommand(
                "test@test.com",
                "password"
            );

            var result = _sut.Validate(command);
            
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("","password")]
        [InlineData(null,"password")]
        [InlineData("test@test.com","")]
        [InlineData("test@test.com",null)]
        public void MustCreateInvalidLoginCommand(
            string email,
            string password
        )
        {
            var command = new LoginCommand(
                email,
                password
            );

            var result = _sut.Validate(command);
            
            Assert.False(result.IsValid);
        }
    }
}