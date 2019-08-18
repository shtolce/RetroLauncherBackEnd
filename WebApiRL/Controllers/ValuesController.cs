using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiRL.Model;
using WebApiRL.Services;

namespace WebApiRL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ObservableCollection<Game> _games;
        private RepositoryBase _repositoryBase;
        public ValuesController(RepositoryBase repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<ObservableCollection<Game>> GetAll()
        {
            _games = new ObservableCollection<Game>((await _repositoryBase.GetGamesAsync()).Distinct());
            Response.Headers.Add("testValue", "120");
            Response.Cookies.Append("testValue", "120");
            return _games;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Game> Get(int id)
        {
            Game _game = await _repositoryBase.GetGameByIdAsync(id);
            Response.Headers.Add("testValue", "120");
            Response.Cookies.Append("testValue", "120");
            return _game;
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
