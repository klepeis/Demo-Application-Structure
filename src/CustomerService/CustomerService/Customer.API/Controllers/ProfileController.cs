﻿using System;
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
        public ActionResult<CustomerProfile> GetCustomerProfile(long id)
        {
            return _customerProfileBO.GetProfile(id);
        }

        // POST: api/Profile
        [HttpPost]
        public ActionResult<CustomerProfile> Add([FromBody] CustomerProfile profileToAdd)
        {
            CustomerProfile newProfile = _customerProfileBO.AddProfile(profileToAdd);
            return CreatedAtAction(nameof(GetCustomerProfile), new { id = newProfile.Id }, newProfile);
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
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
        public IActionResult Delete(long id)
        {
            //Somehow return NotFound;

            _customerProfileBO.DeleteProfile(id);

            return NoContent();
        }
    }
}