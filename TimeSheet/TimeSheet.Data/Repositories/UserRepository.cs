using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Data.Data;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<UserEntity> _users;
        private readonly DatabaseContex _context;

        public UserRepository(DatabaseContex context, IMapper mapper)
        {
            _context = context;
            _users = context.Set<UserEntity>();
            _mapper = mapper;
        }

        public async Task Add(User user)
        {
            try
            {
                UserEntity userEntity = _mapper.Map<UserEntity>(user);
                await _users.AddAsync(userEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add user.", ex);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                UserEntity userDb = await _users.FirstOrDefaultAsync(p => p.Id == id);
                if (userDb == null)
                    throw new Exception("NotFound");

                _users.Remove(userDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete user.", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                List<UserEntity> users = await _users.ToListAsync();

                List<User> result = users.Select(userEntity => _mapper.Map<UserEntity, User>(userEntity)).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve users.", ex);
            }
        }

        public async Task<User> GetById(string id)
        {
            try
            {
                UserEntity userEntity = await _users.FirstOrDefaultAsync(p => p.Id == id.ToString());

                if (userEntity != null)
                {
                    return _mapper.Map<User>(userEntity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get user by ID.", ex);
            }
        }

        public async Task Update(User user)
        {
            try
            {
                UserEntity userEntity = await _users.FirstOrDefaultAsync(p => p.Id == user.Id.ToString());
                if (userEntity == null)
                    throw new Exception("NotFound");

                userEntity.Name = user.Name;
                userEntity.Email = user.Email;
                userEntity.Password = user.Password;
                userEntity.Status = user.Status;
                userEntity.Role = user.Role;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw  new Exception("Failed to update user.", ex);
            }
        }
    }
}
