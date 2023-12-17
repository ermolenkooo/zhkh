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
using DAL.Entities;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterController : ControllerBase
    {
        IDbCrud crudServ;
        public MeterController(zhkh context)
        {
            crudServ = new DbDataOperations(context);
        }

        [HttpPut("{id}/{reading}")]
        public IActionResult Update([FromRoute] int id, [FromRoute] int reading)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            crudServ.UpdateReading(id, reading);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IEnumerable<MeterModel> GetMeters([FromRoute] int id)
        {
            return crudServ.GetMetersOfAddress(id);
        }
    }
}
