using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Crud.Models;

namespace Crud.Controllers
{

    public class ComputerController : Controller
    {

        ComputerDataAccessLayer objComputer = new ComputerDataAccessLayer();

        [HttpGet("[action]")]
        [Route("api/Computer/Index")]
        public IEnumerable<Computer> Index()
        {
            return objComputer.GetAllComputer();
        }

        [HttpPost]
        [Route("api/Computer/Create")]
        public int Create([FromBody] Computer computer)
        {
            return objComputer.NewComputer(computer);
        }

        [HttpGet]
        [Route("api/Computer/Details/{id}")]
        public Computer Details(int id)
        {
            return objComputer.GetComputerData(id);
        }

        [HttpPut]
        [Route("api/Computer/Edit")]
        public int Edit([FromBody]Computer computer)
        {
            return objComputer.UpdateComputer(computer);
        }

        [HttpDelete]
        [Route("api/Computer/Delete/{id}")]
        public int Delete(int id)
        {
            return objComputer.DeleteComputer(id);
        }
    }
}
