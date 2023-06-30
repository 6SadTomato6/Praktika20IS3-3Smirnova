using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;
        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }
        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);

        }
        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] {new Customer() { CustomerFname="",CustomerLname="",CustomerEmail="",Role=""} },
                new object[]{new Customer { CustomerFname="Test",CustomerLname="",CustomerEmail="",Role=""} },
                new object[]{new Customer { CustomerFname="Test",CustomerLname="Test",CustomerEmail="",Role=""} },
                new object[]{new Customer { CustomerFname = "Test", CustomerLname = "Test", CustomerEmail = "Test", Role = "" } },
                new object[]{new Customer { CustomerFname = "Test", CustomerLname = "Test", CustomerEmail = "Test", Role = "Test" } },
            };
        }
        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser()
        {
            //arrange
            var newUser = new Customer()
            {
                CustomerFname = "Test",
                CustomerLname = "",
                CustomerEmail = "",
                Role="",
            };
            //act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            //assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new Customer()
            {
                CustomerEmail = "",
                CustomerLname = "",
                CustomerFname = "",
                Role = ""
            };
            //act
            await service.Create(newUser);
            //assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<Customer>()), Times.Once);
        }
    }
}
