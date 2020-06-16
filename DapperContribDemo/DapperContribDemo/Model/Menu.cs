using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace DapperContribDemo.Model
{

    [Table("Menu")]
    public class Menu
    {
        private readonly string conn = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = DapperContrib; Integrated Security = True";

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedIn { get; set; }

        public Menu Read(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                return connection.Get<Menu>(id);
            }
        }
        public long Insert(Menu menu)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                return connection.Insert(menu);
            }
        }
        public void Update(Menu menu)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Update(menu);
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Delete(new Menu() { Id = id });
            }
        }


    }
}
