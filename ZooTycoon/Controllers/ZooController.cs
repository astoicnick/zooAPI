using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZooTycoon.Data;

namespace ZooTycoon.Controllers
{
    [RoutePrefix("api/zoo")]
    public class ZooController : ApiController
    {
        private ZooTycoonContext _ctx = new ZooTycoonContext();

        [HttpPost]
        [Route("createzookeeper")]
        public IHttpActionResult CreateZookeeper(Zookeeper zookeeperToCreate)
        {
            _ctx.Zookeepers.Add(zookeeperToCreate);
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("createanimal")]
        public IHttpActionResult CreateAnimal(Animal animalToCreate)
        {
            Animal animalCreated = _ctx.Animals.Add(animalToCreate);
            Zookeeper zookeeperToIncrement = _ctx.Zookeepers.Find(animalToCreate.ZookeeperId);
            zookeeperToIncrement.AnimalsCaringFor += 1;
            _ctx.SaveChanges();
            return Ok();
        }
    }
}
