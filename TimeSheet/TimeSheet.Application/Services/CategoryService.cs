using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;

namespace TimeSheet.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public  Task Add(Category category)
        {
            
            return _categoryRepository.Add(category);
        }

        public async Task Delete(Guid id)
        {
            await _categoryRepository.Delete(id.ToString());
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Task<Category> GetById(Guid id)
        {
            return _categoryRepository.GetById(id.ToString());
        }

        public async Task Update(Category category)
        {
            await _categoryRepository.Update(category);
        }
    }
}
