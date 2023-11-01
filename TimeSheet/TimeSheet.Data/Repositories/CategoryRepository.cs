using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TimeSheet.Data.Data;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<CategoryEntity> _categories;
        private readonly DatabaseContex _context;

        public CategoryRepository(DatabaseContex context)
        {
            _context = context;
            _categories = context.Set<CategoryEntity>();
        }

        public async Task Add(Category category)
        {
            try
            {
                await _categories.AddAsync(new CategoryEntity { Id = category.Id.ToString(), Name = category.Name });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add category.", ex);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                CategoryEntity categoryDb = await _categories.FirstOrDefaultAsync(p => p.Id == id);
                if (categoryDb == null)
                    throw new Exception("NotFound");

                _categories.Remove(categoryDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to update category.", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                List<CategoryEntity> countries = await _categories.ToListAsync();

                List<Category> result = new List<Category>();
                foreach (CategoryEntity categoryEntity in countries) 
                {
                    Category category = new Category() { Id = Guid.Parse(categoryEntity.Id), Name = categoryEntity.Name };
                    result.Add(category);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve countries.", ex);
            }
        }

        public async Task<Category> GetById(string id)
        {
            try
            {
                CategoryEntity categoryDb = await _categories.FirstOrDefaultAsync(p => p.Id == id);

                if (categoryDb != null)
                {
                    return new Category { Id = Guid.Parse(categoryDb.Id), Name = categoryDb.Name };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get category by ID.", ex);
            }
        }

        public async Task Update(Category category)
        {
            try
            {
                CategoryEntity categoryDb = await _categories.FirstOrDefaultAsync(p => p.Id == category.Id.ToString());
                if (categoryDb == null)
                    throw new Exception("NotFound");

                categoryDb.Name = category.Name;
                await _context.SaveChangesAsync(); 
            }
            catch (Exception ex)
            {
               
                throw new Exception("Failed to update category.", ex);
            }
        }

    }
}
