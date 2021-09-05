using System.Threading.Tasks;
using Moq;
using Volvo.Services.Trucks.Domain.Commands.Users.Add;
using Volvo.Services.Trucks.Domain.Entities.Security;
using Volvo.Services.Trucks.Domain.Interfaces;

namespace Volvo.Services.Trucks.Domain.Tests.Commands.Users.Add
{
    public class AddUserCommandHandlerTest
    {
        private readonly AddUserCommandHandler _sut;
        private readonly Mock<IRepository<User>> _repository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public AddUserCommandHandlerTest()
        {
            _repository = new Mock<IRepository<User>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _sut = new AddUserCommandHandler(
                _repository.Object,
                _unitOfWork.Object
            );
        }

        public async Task MustAddUserSuccesfully()
        {
            await _sut.Handle(new AddUserCommand(),default);

            _repository.Verify(m => m.InsertAsync(It.IsAny<User>()),Times.Once);
            _unitOfWork.Verify(m => m.SaveChangesAsync(),Times.Never);
        }
    }
}