using Microsoft.AspNetCore.Mvc;
using ppedv.Cooky.Logic;
using ppedv.Cooky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.Cooky.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezeptApiController : ControllerBase
    {
        Core core = new Core();


        // GET: api/<RezeptApiController>
        [HttpGet]
        public IEnumerable<Rezept> Get()
        {
            return core.UnitOfWork.RezeptRepository.Query().ToList();
        }

        // GET api/<RezeptApiController>/5
        [HttpGet("{id}")]
        public Rezept  Get(int id)
        {
            return core.UnitOfWork.RezeptRepository.GetById(id);
        }

        // POST api/<RezeptApiController>
        [HttpPost]
        public void Post([FromBody] Rezept rez)
        {
            core.UnitOfWork.RezeptRepository.Add(rez);
            core.UnitOfWork.SaveAll();
        }

        // PUT api/<RezeptApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Rezept rez)
        {
            rez.Id = id;
            core.UnitOfWork.RezeptRepository.Update(rez);
            core.UnitOfWork.SaveAll();
        }

        // DELETE api/<RezeptApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var loaded = core.UnitOfWork.RezeptRepository.GetById(id);
            if (loaded != null)
            {
                core.UnitOfWork.RezeptRepository.Delete(loaded);
                core.UnitOfWork.SaveAll();
            }
        }
    }
}
