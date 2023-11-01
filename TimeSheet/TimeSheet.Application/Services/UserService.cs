using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;

namespace TimeSheet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Add(User user)
        {
            
            _userRepository.Add(user);
        }

        public async Task Delete(User user)
        {
            _userRepository.Delete(user.Id.ToString());
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<User> GetById(Guid id)
        {
            return _userRepository.GetById(id.ToString());
        }

        public  Task Update(User user)
        {
           return _userRepository.Update(user);
        }
    }
}
