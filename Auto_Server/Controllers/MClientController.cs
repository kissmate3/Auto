using Auto_Common.Models;
using Auto_Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auto_Server.Controllers
{
    [ApiController]
    [Route("api/mclient")]
    public class MClientController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<MClient>> Get()
        {
            //return Ok(new[] { new MClient { FirstName = "Jhon", LastName = "Doe", CarType = "Toyota", LicensePN = "KGB-456", Description = "oil change", StartingDate = DateTime.Now } });

            var mclients = MClientRepository.GetMClients();
            return Ok(mclients);
        }

        [HttpGet("{id}")]
        public ActionResult<MClient> Get(int id) 
        {
            var mclients = MClientRepository.GetMClients();
            var mclient = mclients.FirstOrDefault(x => x.Id == id);

            if (mclient != null) 
            {
                return Ok(mclient);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody]MClient mclient) 
        {
            var mclients = MClientRepository.GetMClients().ToList();

            mclient.Id = GetNewId(mclients);
            mclients.Add(mclient);

            MClientRepository.StoreMClient(mclients);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] MClient mclient)
        {
            var mclients = MClientRepository.GetMClients().ToList();

            var mclientToUpdate = mclients.FirstOrDefault(p => p.Id == mclient.Id);
            if (mclientToUpdate != null)
            {
                mclientToUpdate.FirstName = mclient.FirstName;
                mclientToUpdate.LastName = mclient.LastName;
                mclientToUpdate.CarType = mclient.CarType;
                mclientToUpdate.LicensePN = mclient.LicensePN;
                mclientToUpdate.Description = mclient.Description;
                mclientToUpdate.StartingDate = mclient.StartingDate;

                MClientRepository.StoreMClient(mclients);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var mclients = MClientRepository.GetMClients().ToList();

            var mclientToDelete = mclients.FirstOrDefault(p => p.Id == id);
            if (mclientToDelete != null)
            {
                mclients.Remove(mclientToDelete);
                MClientRepository.StoreMClient(mclients);
                return Ok();
            }

            return NotFound();
        }


        private long GetNewId(IEnumerable<MClient> mclients)
        {
            long newId = 0;
            foreach (var mclient in mclients)
            {
                if (newId < mclient.Id)
                {
                    newId = mclient.Id;
                }
            }

            return newId + 1;
        }

    }
}
