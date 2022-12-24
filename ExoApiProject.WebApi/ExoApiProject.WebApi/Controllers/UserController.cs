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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iUserRepository;
        public UserController(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            try
            {
                return Ok(_iUserRepository.ListUsers());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "0")]
        public IActionResult Update(int id, User user)
        {
            try
            {
                _iUserRepository.Update(id, user);
                return Ok("User updated with successfully!");
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
                User user = _iUserRepository.SearchById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
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
                _iUserRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                _iUserRepository.Register(user);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
