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
    public class CategoriesController : ControllerBase
    {
        IDbCrud crudServ;
        public CategoriesController(zhkh context)
        {
            crudServ = new DbDataOperations(context);
        }

        [HttpGet("service/{id}")]
        public IActionResult GetServiceCategory([FromRoute] int id)
        {
            return Ok(crudServ.GetServiceCategory(id));
        }

        [HttpGet("meter/{id}")]
        public IActionResult GetMeterCategory([FromRoute] int id)
        {
            return Ok(crudServ.GetMeterCategory(id));
        }
    }
}
