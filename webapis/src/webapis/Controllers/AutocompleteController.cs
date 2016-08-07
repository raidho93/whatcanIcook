using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace webapis.Controllers
{
    [Route("api/[controller]")]
    public class AutocompleteController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "You have been hacked" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            string query = "";
            string connectionString = "server=whatcanicook.ml;user id=root;persistsecurityinfo=True;database=whatcanicook_test";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            return id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
