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

namespace zhkh_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterController : ControllerBase
    {
        IDbCrud crudServ;
        public MeterController()
        {
            crudServ = new DbDataOperations();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] int reading)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            crudServ.UpdateReading(id, reading);
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<MeterModel> GetMeters([FromRoute] int id)
        {
            return crudServ.GetMetersOfAddress(id);
        }
    }
}
