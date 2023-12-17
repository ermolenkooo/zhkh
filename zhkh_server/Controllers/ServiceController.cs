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
    public class ServiceController : ControllerBase
    {
        IDbCrud crudServ;
        public ServiceController()
        {
            crudServ = new DbDataOperations();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            crudServ.UpdateStatusOfService(id);
            return NoContent();
        }

        [HttpGet("unpaid/{id}")]
        public IEnumerable<ServiceModel> GetUnpaidServices([FromRoute] int id)
        {
            return crudServ.GetUnpaidServices(id);
        }

        [HttpGet("paid/{id}")]
        public IEnumerable<ServiceModel> GetPaidServices([FromRoute] int id)
        {
            return crudServ.GetPaidServices(id);
        }
    }
}
