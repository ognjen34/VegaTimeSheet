using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Data.Data;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Exceptions;

namespace TimeSheet.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<UserEntity> _users;
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _users = context.Set<UserEntity>();
            _mapper = mapper;
        }

        public async Task Add(User user)
        {
            UserEntity existingUser = await _users.FirstOrDefaultAsync(p => p.Email == user.Email);
            if (existingUser != null) 
            {
                throw new EmailAlreadyExistException($"{user.Email} is already in use");
            }
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            string salt = "$2a$12$abcdefghijklmno1234567";
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(userEntity.Password, salt);
            await _users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            UserEntity userDb = await _users.FirstOrDefaultAsync(p => p.Id == id);
            if (userDb == null)
            {
                throw new ResourceNotFoundException("User not found");
            }

            _users.Remove(userDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            List<UserEntity> users = await _users.ToListAsync();
            List<User> result = users.Select(userEntity => _mapper.Map<User>(userEntity)).ToList();
            return result;
        }

        public async Task<User> GetById(string id)
        {
            UserEntity userEntity = await _users.FirstOrDefaultAsync(p => p.Id == id.ToString());
            if (userEntity == null)
            {
                throw new ResourceNotFoundException("User not found");
            }
            return _mapper.Map<User>(userEntity);
        }

        public async Task<User> GetByEmailAndPassword(string email,string password)
        {
            string salt = "$2a$12$abcdefghijklmno1234567";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            UserEntity userEntity = await _users.FirstOrDefaultAsync(p => p.Email == email && p.Password == hashedPassword);

            
            if (userEntity == null)
            {
                throw new ResourceNotFoundException("Wrong Credentials");
            }
            return _mapper.Map<User>(userEntity);

        }

        public async Task Update(User user)
        {
            UserEntity userEntity = await _users.FirstOrDefaultAsync(p => p.Id == user.Id.ToString());
            if (userEntity == null)
            {
                throw new ResourceNotFoundException("User not found");
            }
            string salt = "$2a$12$abcdefghijklmno1234567";
            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
            userEntity.Status = user.Status;
            userEntity.Role = user.Role;
            userEntity.WorkingHours = user.WorkingHours;

            await _context.SaveChangesAsync();
        }

    }
}
