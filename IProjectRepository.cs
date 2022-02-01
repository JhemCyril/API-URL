using Project.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.API.Repository
{
    public interface IProjectRepository
    {
        Task<List<BookModel>> GetAllProjectAsync();
        Task<BookModel> GetProjectByModelIdAsync(int modelid);
        Task<int> AddProjectAsync(ProjectModel projectmodel);
        Task UpdateProjectAsync(int modelid, ProjectModel projectmodel);
        Task UpdateProjectPatchAsync(int modelid, JsonPatchDocument projectmodel);
        Task DeleteProjectAsync(int modelid);
    }
}