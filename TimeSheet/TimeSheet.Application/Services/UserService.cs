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
            
            await _userRepository.Add(user);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id.ToString());
        }

        public Task<PaginationReturnObject<User>> Search(Pagination page)
        {
            return _userRepository.Search(page);
        }

        public Task<User> GetById(Guid id)
        {
            return _userRepository.GetById(id.ToString());
        }

        public Task<User> Login(string username, string password)
        {
            return _userRepository.GetByEmailAndPassword(username, password);
        }

        public  Task Update(User user)
        {
           return _userRepository.Update(user);
        }
    }
}
