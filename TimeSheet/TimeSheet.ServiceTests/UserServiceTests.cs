using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Application.Services;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
namespace TimeSheet.ServiceTests
{
    [TestClass]
    public class UserServiceTests
    {

        private IUserService _userService;

        private Mock<IUserRepository> _userRepositoryMock;
        [TestInitialize]
        public void TestInitialize()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }
        public User GenerateUser()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "Test",
                Password = "Test",
                WorkingHours = 1,
                Role = Role.Worker,
                Status = Status.Active
            };
        }

        [TestMethod]
        public async Task Add_ValidUser_Success()
        {


            var user = GenerateUser();

            _userRepositoryMock.Setup(repo => repo.Add(user)).Returns(Task.CompletedTask);

            await _userService.Add(user);

            _userRepositoryMock.Verify(repo => repo.Add(user), Times.Once);
        }
        [TestMethod]

        public async Task Add_UserWithSameEmail_ThrowsException()
        {
            var user = GenerateUser();
            var existingUser = GenerateUser();

            _userRepositoryMock.Setup(repo => repo.Add(user))
                .Returns(Task.CompletedTask);

            _userRepositoryMock.Setup(repo => repo.Add(existingUser))
                .Throws<EmailAlreadyExistException>();

            await _userService.Add(user);

            _userRepositoryMock.Verify(repo => repo.Add(user), Times.Once);

            await Assert.ThrowsExceptionAsync<EmailAlreadyExistException>(() => _userService.Add(existingUser));
        }

        [TestMethod]
        public async Task Delete_ValidUserId_Success()
        {
            var userId = Guid.NewGuid();

            var userRepositoryMock = new Mock<IUserRepository>();

            var userService = new UserService(userRepositoryMock.Object);

            userRepositoryMock.Setup(repo => repo.Delete(userId.ToString())).Returns(Task.CompletedTask);

            await userService.Delete(userId);

            userRepositoryMock.Verify(repo => repo.Delete(userId.ToString()), Times.Once);
        }
        [TestMethod]
        public async Task GetAll_ReturnsListOfUsers()
        {
            var users = new List<User>
                {
                    GenerateUser(),
                    GenerateUser(),
                    GenerateUser()
                };

            _userRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(users);

            var result = await _userService.GetAll();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<User>));
            CollectionAssert.AreEqual(users.ToList(), result.ToList());
        }
        [TestMethod]
        public async Task GetById_ExistingUser_ReturnsUser()
        {
            var user = GenerateUser();
            var userId = user.Id;

            _userRepositoryMock.Setup(repo => repo.GetById(userId.ToString()))
                .ReturnsAsync(user);

            var result = await _userService.GetById(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.Id);
        }

        [TestMethod]
        public async Task GetById_NonExistingUser_ThrowsResourceNotFoundException()
        {
            var nonExistingUserId = Guid.NewGuid(); 

            _userRepositoryMock.Setup(repo => repo.GetById(nonExistingUserId.ToString()))
                .Throws<ResourceNotFoundException>();

            await Assert.ThrowsExceptionAsync<ResourceNotFoundException>(() => _userService.GetById(nonExistingUserId));
        }
        [TestMethod]
        public async Task Login_ValidCredentials_ReturnsUser()
        {
            var user = GenerateUser();
            var username = user.Email;
            var password = "test"; 

            _userRepositoryMock.Setup(repo => repo.GetByEmailAndPassword(username, password))
                .ReturnsAsync(user);

            var result = await _userService.Login(username, password);

            Assert.IsNotNull(result);
            Assert.AreEqual(username, result.Email);
        }

        [TestMethod]
        public async Task Login_IncorrectCredentials_ThrowsResourceNotFoundException()
        {
            var username = "test"; 
            var password = "test"; 

            _userRepositoryMock.Setup(repo => repo.GetByEmailAndPassword(username, password))
                .Throws<ResourceNotFoundException>();

            await Assert.ThrowsExceptionAsync<ResourceNotFoundException>(() => _userService.Login(username, password));
        }
        [TestMethod]

        public async Task Update_ExistingUser_Success()
        {
            var user = GenerateUser();

            _userRepositoryMock.Setup(repo => repo.Update(user)).Returns(Task.CompletedTask);

            await _userService.Update(user);

            _userRepositoryMock.Verify(repo => repo.Update(user), Times.Once);


        }

        [TestMethod]
        public async Task Update_NonExistingUser_ThrowsResourceNotFoundException()
        {
            var user = GenerateUser(); 

            _userRepositoryMock.Setup(repo => repo.Update(user))
                .Throws<ResourceNotFoundException>();

            await Assert.ThrowsExceptionAsync<ResourceNotFoundException>(() => _userService.Update(user));
        }



    }

}