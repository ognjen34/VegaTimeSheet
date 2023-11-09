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
    public class ProjectRepository : IProjectRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<ProjectEntity> _projects;
        private readonly DatabaseContext _context;

        public ProjectRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _projects = context.Set<ProjectEntity>();
            _mapper = mapper;
        }

        public async Task Add(Project project)
        {
            ProjectEntity projectEntity = _mapper.Map<ProjectEntity>(project);
            await _projects.AddAsync(projectEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            ProjectEntity projectDb = await _projects.FirstOrDefaultAsync(p => p.Id == id);
            if (projectDb == null)
            {
                throw new ResourceNotFoundException("Project not found");
            }

            _projects.Remove(projectDb);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginationReturnObject<Project>> Search(PaginationFilter page)
        {
            IQueryable<ProjectEntity> query = _projects;

            if (!string.IsNullOrEmpty(page.StringQuery))
            {
                query = query.Where(projectEntity => projectEntity.Name.Contains(page.StringQuery));
            }

            if (!string.IsNullOrEmpty(page.FirstLetter))
            {
                query = query.Where(projectEntity => projectEntity.Name.ToLower().StartsWith(page.FirstLetter.ToLower()));
            }

            int totalCount = await query.CountAsync();


            var queryWithCount = new
            {
                TotalCount = _projects.Count(),
                Projects = query
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToList()
            };
            
            PaginationReturnObject<Project> result = new PaginationReturnObject<Project>(_mapper.Map<IEnumerable<Project>>(queryWithCount.Projects), page.PageNumber, page.PageSize, queryWithCount.TotalCount);


            return result;
        }

        public async Task<Project> GetById(string id)
        {
            ProjectEntity projectEntity = await _projects.FirstOrDefaultAsync(p => p.Id == id.ToString());

            if (projectEntity != null)
            {
                return _mapper.Map<Project>(projectEntity);
            }
            else
            {
                throw new ResourceNotFoundException("Project not found");
            }
        }

        public async Task Update(Project project)
        {
            ProjectEntity projectEntity = await _projects.FirstOrDefaultAsync(p => p.Id == project.Id.ToString());
            if (projectEntity == null)
            {
                throw new ResourceNotFoundException("Project not found");
            }

            projectEntity.Name = project.Name;
            projectEntity.Description = project.Description;
            projectEntity.Client = _mapper.Map<ClientEntity>(project.Client);
            projectEntity.Lead = _mapper.Map<UserEntity>(project.Lead);
            projectEntity.LeadId = project.LeadId.ToString();
            projectEntity.ClientId = project.ClientId.ToString();

            projectEntity.Status = project.Status;


            await _context.SaveChangesAsync();
        }
    }
}
