using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProductApi.Models;
using MySql.Data.MySqlClient;

namespace ProductApi.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Connect conn = new();
    
        [HttpGet]
        public List<Products> Get() {

            List<Products> products = new List<Products>();

            conn.Connection.Open();
            string sql = "SELECT * FROM products";

            MySqlCommand cmd = new MySqlCommand(sql,conn.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            do
            {
                var result = new Products()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2),
                    CreatedTime = reader.GetDateTime(3),
                };
                products.Add(result);
            }
            while (reader.Read());

            conn.Connection.Close();
            return products;
        }
    }
}
