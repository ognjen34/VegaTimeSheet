using Microsoft.EntityFrameworkCore;
using TimeSheet.Data.Models;
using TimeSheet.Data.Repositories;
using TimeSheet.Domain.Models;
using AutoMapper;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Data.Data;
using TimeSheet.Domain.Exceptions;

namespace TimeSheet.RepositoryTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private IUserRepository userRepository;
        private DatabaseContext testDbContext;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: nameof(UserRepositoryTests))
                .Options;

            testDbContext = new DatabaseContext(options);

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<UserEntity, User>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
            });
            IMapper mockMapper = configuration.CreateMapper();

            userRepository = new UserRepository(testDbContext, mockMapper);

        }
        [TestCleanup]
        public void TestCleanup()
        {
            testDbContext.Users.RemoveRange(testDbContext.Users);
            testDbContext.SaveChanges();

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

            await userRepository.Add(user);

            var addedUser = await testDbContext.Users.FirstOrDefaultAsync();
            Assert.IsNotNull(addedUser);
            Assert.AreEqual(user.Email, addedUser.Email);

        }
        [TestMethod]
        public async Task Add_User_SameEmail()
        {
            var user = GenerateUser();

            var user2 = GenerateUser();

            await userRepository.Add(user);


            Assert.ThrowsException<EmailAlreadyExistException>(() => userRepository.Add(user2).GetAwaiter().GetResult());


        }
        [TestMethod]
        public async Task Get_User_Success()
        {
            User user = GenerateUser();

            Guid id = Guid.NewGuid();

            user.Id = id;

            await userRepository.Add(user);

            User testUser = await userRepository.GetById(id.ToString());

            Assert.AreEqual(user.Email, testUser.Email);



        }
        [TestMethod]

        public async Task Get_User_NotFound()
        {
            User user = GenerateUser();

            Guid id = Guid.NewGuid();

            await userRepository.Add(user);

            Assert.ThrowsException<ResourceNotFoundException>(() => userRepository.GetById(id.ToString()).GetAwaiter().GetResult());

        }
        [TestMethod]
        public async Task Delete_User_Successful()
        {
            User user = GenerateUser();

            Guid id = Guid.NewGuid();

            user.Id = id;

            await userRepository.Add(user);

            User testUser = await userRepository.GetById(id.ToString());

            Assert.AreEqual(user.Email, testUser.Email);

            await userRepository.Delete(id.ToString());

            Assert.ThrowsException<ResourceNotFoundException>(() => userRepository.GetById(id.ToString()).GetAwaiter().GetResult());


        }
        [TestMethod]

        public async Task Delete_User_ResourceNotFound()
        {

            Guid id = Guid.NewGuid();


            Assert.ThrowsException<ResourceNotFoundException>(() => userRepository.GetById(id.ToString()).GetAwaiter().GetResult());


        }
        [TestMethod]

        public async Task Update_User_Successful()
        {
            User user = GenerateUser();

            Guid id = Guid.NewGuid();

            user.Id = id;

            await userRepository.Add(user);

            string newName = "Pera";

            User testUser = await userRepository.GetById(id.ToString());

            testUser.Name = newName;

            await userRepository.Update(testUser);

            testUser = await userRepository.GetById(id.ToString());


            Assert.AreNotEqual(user.Name, testUser.Name);
            Assert.AreEqual(newName, testUser.Name);



        }
        [TestMethod]

        public async Task Update_User_ResourceNotFound()
        {
            Assert.ThrowsException<ResourceNotFoundException>(() => userRepository.Update(GenerateUser()).GetAwaiter().GetResult());
        }

        public async Task GetByEmailAndPassword_UserFoundSuccessfully_UserReturned()
        {
            User user = GenerateUser();



            await userRepository.Add(user);

            User testUser = await userRepository.GetByEmailAndPassword(user.Email,user.Password);

            Assert.AreEqual(user.Name, testUser.Name);



        }
        [TestMethod]

        public async Task Get_User_WrongCredentials()
        {


            string expectedMessage = "Wrong Credentials"; 
            string actualMessage = null;

            try
            {
                await userRepository.GetByEmailAndPassword("test", "test");
            }
            catch (ResourceNotFoundException ex)
            {
                actualMessage = ex.Message;
            }

            Assert.AreEqual(expectedMessage, actualMessage);

        }


    }
}