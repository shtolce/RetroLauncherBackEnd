using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiRL.Model;
using WebApiRL.Services;

namespace WebApiRL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration Config;
        private ObservableCollection<Game> _games;
        public ValuesController(IConfiguration config)
        {
            _games = new ObservableCollection<Game>(Services.RepositoryBase.GetGamesAsync(config).Result.Distinct());

            this.Config = config;


        }
        
        // GET api/values
        [HttpGet]
        public ObservableCollection<Game> Get()
        {
            
            return _games;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
