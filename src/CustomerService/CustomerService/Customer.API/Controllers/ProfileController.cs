﻿using Customer.Domain.Profile.BusinessObjects;
using Customer.Domain.Profile.BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ICustomerProfileBO _customerProfileBO;

        public ProfileController(ICustomerProfileBO customerProfileBO)
        {
            _customerProfileBO = customerProfileBO ?? throw new ArgumentNullException(nameof(customerProfileBO));
        }

        // GET: api/Profile
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Profile/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(CustomerProfileDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerProfileDTO> GetCustomerProfile(long id)
        {
            var result = _customerProfileBO.GetProfile(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Profile
        [HttpPost]
        [ProducesResponseType(typeof(CustomerProfileDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerProfileDTO> AddCustomerProfile([FromBody] CustomerProfileDTO profileToAdd)
        {
            if (ModelState.IsValid)
            {
                CustomerProfileDTO newProfile = _customerProfileBO.AddProfile(profileToAdd);
                return CreatedAtAction(nameof(GetCustomerProfile), new { id = newProfile.Id }, newProfile);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateCustomerProfile(long id, [FromBody] CustomerProfileDTO profileToUpdate)
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
        public ActionResult DeleteCustomerProfile(long id)
        {
            //Somehow return NotFound;

            _customerProfileBO.DeleteProfile(id);

            return NoContent();
        }
    }
}
