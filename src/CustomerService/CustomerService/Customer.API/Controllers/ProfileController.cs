using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Profile.BusinessObjects;
using Customer.Profile.BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ICustomerProfileBO _customerProfileBO;

        public ProfileController(ICustomerProfileBO customerProfileBO)
        {
            _customerProfileBO = customerProfileBO;
        }

        // GET: api/Profile
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Profile/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(CustomerProfile), StatusCodes.Status200OK)]
        public ActionResult<CustomerProfile> GetCustomerProfile(long id)
        {
            return Ok(_customerProfileBO.GetProfile(id));
        }

        // POST: api/Profile
        [HttpPost]
        [ProducesResponseType(typeof(CustomerProfile), StatusCodes.Status201Created)]
        public ActionResult<CustomerProfile> Add([FromBody] CustomerProfile profileToAdd)
        {
            CustomerProfile newProfile = _customerProfileBO.AddProfile(profileToAdd);
            return CreatedAtAction(nameof(GetCustomerProfile), new { id = newProfile.Id }, newProfile);
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update(long id, [FromBody] CustomerProfile profileToUpdate)
        {
            if(id != profileToUpdate.Id)
            {
                return BadRequest();
            }

            _customerProfileBO.UpdateProfile(profileToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(long id)
        {
            //Somehow return NotFound;

            _customerProfileBO.DeleteProfile(id);

            return NoContent();
        }
    }
}
