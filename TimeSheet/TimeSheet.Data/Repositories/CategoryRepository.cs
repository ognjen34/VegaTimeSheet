using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Data.Data;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSet<CategoryEntity> _categories;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _categories = context.Set<CategoryEntity>();
            _mapper = mapper;
        }

        public async Task Add(Category category)
        {
            CategoryEntity categoryEntity = _mapper.Map<CategoryEntity>(category);
            await _categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            CategoryEntity categoryDb = await _categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryDb == null)
            {
                throw new ResourceNotFoundException("Category not found");
            }

            _categories.Remove(categoryDb);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginationReturnObject<Category>> Search(PaginationFilter page)
        {
            IQueryable<CategoryEntity> query = _categories;

            if (!string.IsNullOrEmpty(page.StringQuery))
            {
                query = query.Where(categoryEntity => categoryEntity.Name.Contains(page.StringQuery));
            }

            if (!string.IsNullOrEmpty(page.FirstLetter))
            {
                query = query.Where(categoryEntity => categoryEntity.Name.ToLower().StartsWith(page.FirstLetter.ToLower()));
            }


            var queryWithCountForCategory = new
            {
                TotalCount = _categories.Count(), 
                Categories = query
                    .Skip((page.PageNumber - 1) * page.PageSize)
                    .Take(page.PageSize)
                    .ToList()
            };

            PaginationReturnObject<Category> result = new PaginationReturnObject<Category>(
                _mapper.Map<IEnumerable<Category>>(queryWithCountForCategory.Categories),
                page.PageNumber,
                page.PageSize,
                queryWithCountForCategory.TotalCount
            );


            return result;
        }

        public async Task<Category> GetById(string id)
        {
            CategoryEntity categoryEntity = await _categories.FirstOrDefaultAsync(c => c.Id == id);

            if (categoryEntity != null)
            {
                Category category = _mapper.Map<Category>(categoryEntity);
                return category;
            }
            else
            {
                throw new ResourceNotFoundException("Category not found");
            }
        }

        public async Task Update(Category category)
        {
            CategoryEntity categoryEntity = await _categories.FirstOrDefaultAsync(c => c.Id == category.Id.ToString());
            if (categoryEntity == null)
            {
                throw new ResourceNotFoundException("Category not found");
            }

            categoryEntity.Name = category.Name;
            await _context.SaveChangesAsync();
        }
    }
}
