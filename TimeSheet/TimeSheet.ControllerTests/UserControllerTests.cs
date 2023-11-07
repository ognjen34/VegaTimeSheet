using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Proxies.Internal;
using Moq;
using System.ComponentModel.DataAnnotations;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.WebApi.Controllers;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;

namespace TimeSheet.ControllerTests
{
    [TestClass]
    public class UserControllerTests
    {
        private UserController controller;
        private Mock<IUserService> userServiceMock;

        public User GenerateUser(CreateUserRequest user)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                WorkingHours = user.WorkingHours,
                Role = user.Role,
                Status = user.Status,
            };
        }
        public CreateUserRequest GenerateUserRequest(string email, string password)
        {
            return new CreateUserRequest
            {
                Name = "Test",
                Email = email,
                Password = password,
                WorkingHours = 1,
                Role = Role.Worker,
                Status = Status.Active
            };
        }
        public UserResponse UserResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                WorkingHours = user.WorkingHours,
                Role = user.Role,
                Status = user.Status
            };
        }


        [TestInitialize]
        public void TestInitialize()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUserRequest, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
                cfg.CreateMap<User, UserResponse>();
                cfg.CreateMap<PaginationRequest, Pagination>();
                cfg.CreateMap<UpdateUserRequest, User>()
                

           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));

            });
            IMapper mockMapper = configuration.CreateMapper();
            userServiceMock = new Mock<IUserService>();
            controller = new UserController(userServiceMock.Object, mockMapper);

        }


        [TestMethod]
        public async Task AddUser_ValidUser_ReturnsOkResult()
        {
            var createUserRequest = GenerateUserRequest("test@example.com", "12356789");
            var user = GenerateUser(createUserRequest);

            var validationContext = new ValidationContext(createUserRequest);
            var validationResults = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(createUserRequest, validationContext, validationResults, validateAllProperties: true);

            Assert.IsTrue(isModelStateValid);

            Assert.IsFalse(validationResults.Any());

            userServiceMock.Setup(service => service.Add(It.IsAny<User>())).Returns(Task.FromResult(user));

            var result = await controller.AddUser(createUserRequest);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var response = okResult.Value as UserResponse;
            Assert.IsNotNull(response);
        }
        [TestMethod]
        public async Task AddUser_InvalidEmail()
        {
            var createUserRequest = GenerateUserRequest("test", "12356789");

            var validationContext = new ValidationContext(createUserRequest);
            var validationResults = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(createUserRequest, validationContext, validationResults, validateAllProperties: true);

            Assert.IsFalse(isModelStateValid);


        }
        [TestMethod]
        public async Task AddUser_InvalidPassword()
        {
            var createUserRequest = GenerateUserRequest("test@example.com", "123");

            var validationContext = new ValidationContext(createUserRequest);
            var validationResults = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(createUserRequest, validationContext, validationResults, validateAllProperties: true);

            Assert.IsFalse(isModelStateValid);


        }
        [TestMethod]
        public async Task Login_LoginSuccesfully_ReturnOkWithToken()
        {
            var createUserRequest = GenerateUserRequest("test@example.com", "123456789");
            var user = GenerateUser(createUserRequest);

            userServiceMock.Setup(service => service.Login("test@example.com", "123456789"))
                .ReturnsAsync(user);

            var loginRequest = new LoginRequest
            {
                Email = "test@example.com",
                Password = "123456789",
            };

            var result = await controller.Login(loginRequest);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [TestMethod]
        public async Task Login_WrongPassword_ReturnUnauthorized()
        {
            var createUserRequest = GenerateUserRequest("test@example.com", "123456789");
            var user = GenerateUser(createUserRequest);

            userServiceMock.Setup(service => service.Login("test@example.com", "123456789"))
                .ReturnsAsync(user);

            var loginRequest = new LoginRequest
            {
                Email = "test@example.com",
                Password = "1256789",
            };

            var result = await controller.Login(loginRequest);

            var unauthorizedResult = result as UnauthorizedResult;
            Assert.AreEqual(401, unauthorizedResult.StatusCode);


        }
        [TestMethod]
        public async Task Login_WrongEmail_ReturnUnauthorized()
        {
            var createUserRequest = GenerateUserRequest("test@example.com", "123456789");
            var user = GenerateUser(createUserRequest);

            userServiceMock.Setup(service => service.Login("test@example.com", "123456789"))
                .ReturnsAsync(user);

            var loginRequest = new LoginRequest
            {
                Email = "test2@example.com",
                Password = "123456789",
            };

            var result = await controller.Login(loginRequest);

            var unauthorizedResult = result as UnauthorizedResult;
            Assert.AreEqual(401, unauthorizedResult.StatusCode);


        }
        [TestMethod]
        


        public async Task GetById_ExistingUser_ReturnsOkResultWithUser()
        {


            var userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Name = "TestUser",
                Email = "test@example.com",
            };

            userServiceMock.Setup(service => service.GetById(userId))
                .ReturnsAsync(user);


            var result = await controller.GetById(userId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);

            var response = okResult.Value as UserResponse;
            Assert.IsNotNull(response);

        }

        [TestMethod]
        public async Task GetById_NonExistingUser_ReturnsNotFound()
        {


            userServiceMock.Setup(service => service.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((User)null);


            var result = await controller.GetById(Guid.NewGuid());
            if (result is OkObjectResult okResult)
            {
                var userResponse = okResult.Value as UserResponse;

                Assert.IsNull(userResponse);

            }

        }

        [TestMethod]
        public async Task DeleteUser_ExistingUser_ReturnsOkResult()
        {
   

            userServiceMock.Setup(service => service.Delete(It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);


            var result = await controller.DeleteUser(Guid.NewGuid()); 

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual("User Deleted!", okResult.Value.ToString()); 
        }
        [TestMethod]
        public async Task UpdateUser_ExistingUser_ReturnsOkResult()
        {


            var updateUser = new UpdateUserRequest
            {
                Id = (new Guid()).ToString(),
                Name = "test",
                Email = "test",
                Password = "test",


            };

            userServiceMock.Setup(service => service.Update(It.IsAny<User>()))
                .Returns(Task.CompletedTask);


            var result = await controller.UpdateUser(updateUser);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual("User Updated!", okResult.Value.ToString());
        }

    }

}