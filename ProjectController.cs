using Project.API.Models;
using Project.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetAllProject()
        {
            var project = await _projectRepository.GetAllProjectAsync();
            return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectByModelId([FromRoute] int id)
        {
            var project = await _projectRepository.GetProjectByModelIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectModel projectmodel, [FromRoute] int id)
        {
            await _projectRepository.UpdateProjectAsync(id, projectmodel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProjectPatch([FromBody] JsonPatchDocument projectmodel,[FromRoute] int id)
        {
            await _projectRepository.UpdateProjectPatchAsync(id, projectmodel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            await _projectRepository.DeleteProjectAsync(id);
            return Ok;
        }
    }
}