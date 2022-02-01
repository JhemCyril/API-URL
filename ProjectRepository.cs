using Project;
using AddUser.API.Data;
using AddUser.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectListContext _context;
        private readonly IProject _project;

        public ProjectRepository(ProjectListContext context, IProject project)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProjectModel>> GetAllProjectAsync()
        {
            var records = await _context.Project.ToListAsync();
            return _project.Map<List<ProjectModel>>(records);
        }

        public async Task<ProjectModel> GetProjectByModelIdAsync(int modelid)
        {
            var project = await _context.Project.FindAsync(modelid);
            return _project.Map<ProjectModel>(project);
        }

        public async Task<int> AddProjectAsync(ProjectModel projectmodel)
        {
            var project = new Project()
            {
                Title = projectmodel.Title,
                Description = projectmodel.Description
            };

            _context.Project.Add(project);
            await _context.SaveChangesAsync();

            return project.Id;
        }

        public async Task UpdateProjectAsync(int modelid, ProjectModel projectmodel)
        {
            var projec = new Project()
            {
                Id = modelid,
                Title = projectmodel.Title,
                Description = projectmodel.Description
            };

            _context.Project.Update(project)
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectPatchAsync(int modelid, JsonPatchDocument projectmodel)
        {
            var project = await _context.Project.FindAsync(modelid);
            if (project != null)
            {
                projectmodel.ApplyTo(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProjectAsync(int modelid)
        {
            var project = new Project() { Id = modelid };

            _context.Project.Remove(project);

            await _context.SaveChangesAsync();
        }
    }
}