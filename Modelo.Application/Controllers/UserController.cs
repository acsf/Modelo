using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;

namespace Modelo.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Post([FromBody] User item)
        {
            try
            {
                Service.Post<UserValidator>(item);

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
                service.Put<UserValidator>(item);

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