using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Service.Services;
using Modelo.Service.Validators;
using System;

namespace Modelo.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    [ApiController]
    public class UserController : Controller
    {
        private BaseService<User> service = new BaseService<User>();

        public IActionResult Post([FromBody] User item)
        {
            try
            {
                service.Post<UsuarioValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentException ex)
            {

                return NotFound(ex);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Put([FromBody] User item)
        {
            try
            {
                service.Put<UsuarioValidator>(item);

                return new ObjectResult(item);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);

                return new NoContentResult();
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.Get());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }   
        }

        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));

            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}