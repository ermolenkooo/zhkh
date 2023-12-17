using BLL.Interfaces;
using BLL.Models;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;
using BLL.Operations;
using System.IO;

namespace myserver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        IDbCrud crudServ;
        public AddressController()
        {
            crudServ = new DbDataOperations();
        }

        [HttpGet("{id}")]
        public IActionResult GetAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var address = crudServ.GetAddressOfUser(id);
            if (address == null)
                return NotFound();
            else
                return Ok(address);
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressModel a)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var address = crudServ.AddAddress(a);
            if (address == null)
                return NotFound();
            else
                return Ok(address);
        }
    }
}
