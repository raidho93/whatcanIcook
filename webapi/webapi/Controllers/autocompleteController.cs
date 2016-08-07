using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Web.Http;
using System.Data;

namespace webapi.Controllers
{
    public class autocompleteController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "You have been hacked" };
        }

        // GET api/<controller>/5
        public List<string> Get(string id)
        {
            string connStr = "server=whatcanicook.ml;user id=root;password=Danutel1!;persistsecurityinfo=True;database=whatcanicook_test;allowuservariables=True";
            MySqlConnection connection = new MySqlConnection(connStr);
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            List<string> results = new List<string>();

            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "whatcanicook_test.ingredients_autosugest";

                cmd.Parameters.AddWithValue("@text", id);
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    results.Add(reader["name"].ToString().ToUpperInvariant());
                }
            }
            catch (Exception ex)
            {
                connection.Close();
            }
            
            return results;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}