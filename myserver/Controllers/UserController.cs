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
    public class UserController : ControllerBase
    {
        IDbCrud crudServ;
        public UserController()
        {
            crudServ = new DbDataOperations();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel u)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = crudServ.Login(u);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpPost]
        public IActionResult Reg([FromBody] UserModel u)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = crudServ.Reg(u);
            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }
    }
}
