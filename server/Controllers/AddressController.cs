using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Operations;
using BLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        IDbCrud crudServ;
        public AddressController(zhkh context)
        {
            crudServ = new DbDataOperations(context);
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