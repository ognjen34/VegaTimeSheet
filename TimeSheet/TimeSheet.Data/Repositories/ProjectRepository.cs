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
    public class ProjectRepository : IProjectRepository
    {
        private readonly DbSet<ProjectEntity> _projects;
        private readonly DatabaseContex _context;

        public ProjectRepository(DatabaseContex context)
        {
            _context = context;
            _projects = context.Set<ProjectEntity>();
        }

        public async Task Add(Project project)
        {
            try
            {
                await _projects.AddAsync(new ProjectEntity 
                { 
                    Id = project.Id.ToString(), 
                    Name = project.Name,Description = project.Description,
                    Client = project.Client,
                    Lead= project.Lead 
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add project.", ex);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                ProjectEntity projectDb = await _projects.FirstOrDefaultAsync(p => p.Id == id);
                if (projectDb == null)
                    throw new Exception("NotFound");

                _projects.Remove(projectDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete project.", ex);
            }
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            try
            {
                List<ProjectEntity> projects = await _projects.ToListAsync();

                List<Project> result = new List<Project>();
                foreach (ProjectEntity projectEntity in projects)
                {
                    Project project = new Project
                    {
                        Id = Guid.Parse(projectEntity.Id),
                        Name = projectEntity.Name,
                        Description = projectEntity.Description,
                        Client = projectEntity.Client,
                        Lead = projectEntity.Lead
                    };
                    result.Add(project);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve projects.", ex);
            }
        }

        public async Task<Project> GetById(string id)
        {
            try
            {
                ProjectEntity projectEntity = await _projects.FirstOrDefaultAsync(p => p.Id == id.ToString());

                if (projectEntity != null)
                {
                    return new Project
                    {
                        Id = Guid.Parse(projectEntity.Id),
                        Name = projectEntity.Name,
                        Description = projectEntity.Description,
                        Client = projectEntity.Client,
                        Lead = projectEntity.Lead
                    }; ;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get project by ID.", ex);
            }
        }

        public async Task Update(Project project)
        {
            try
            {
                ProjectEntity projectDb = await _projects.FirstOrDefaultAsync(p => p.Id == project.Id.ToString());
                if (projectDb == null)
                    throw new Exception("NotFound");

                projectDb.Name = project.Name;
                projectDb.Description = project.Description;
                projectDb.Client = project.Client;
                projectDb.Lead = project.Lead;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update project.", ex);
            }
        }
    }
}
