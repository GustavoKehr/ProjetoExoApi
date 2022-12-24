using ExoApiProject.WebApi.Interfaces;
using ExoApiProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApiProject.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _IProjectRepository;

        public ProjectController(IProjectRepository iProjectRepository)
        {
            _IProjectRepository = iProjectRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                return Ok(_IProjectRepository.Read());
                    
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "0")]
        public IActionResult Resgister(Project project)
        {
            try
            {
                _IProjectRepository.Register(project);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "0")]
        public IActionResult Update(int id, Project project) 
        {
            try
            {
                _IProjectRepository.Update(id, project);
                return StatusCode(200);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "0")]
        public IActionResult Delete(int id)
        {
            try
            {
                _IProjectRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult SearchById(int id)
        {
            try
            {
                Project project = _IProjectRepository.SearchById(id);
                if (project == null)
                {
                    return NotFound();
                }
                return Ok(project);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("projectname/{projectname}")]
        public IActionResult SearchByName(string projectname)
        {
            try
            {
                Project project = _IProjectRepository.SearchByName(projectname);
                
                if (project == null)
                {
                    return NotFound();
                }
                return Ok(project);
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
