using ConectarDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AutosController : ApiController
    {
        private InverntarioEntities dbContext = new InverntarioEntities();

        //Visualiza todos los registros (https://localhost:44374/Api/Autos)
        [HttpGet]
        public IEnumerable<Autos> Get()
        {
            using (InverntarioEntities inventarioentities = new InverntarioEntities())
            {
                return inventarioentities.Autos.ToList();
            }
        }

        //Visualiza solo un registro (https://localhost:44374/Api/Autos/1)
        [HttpGet]
        public Autos Get(int id)
        {
            using (InverntarioEntities inverntarioEntities = new InverntarioEntities())
            {
                return inverntarioEntities.Autos.FirstOrDefault(e => e.Id == id);
            }
        }

        //Graba Nuevos Registros en la base de datos -autos
        [HttpPost]
        public IHttpActionResult AgregaAutos([FromBody]Autos autos)
        {
            if (ModelState.IsValid)
            {
                dbContext.Autos.Add(autos);
                dbContext.SaveChanges();
                return Ok(autos);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
