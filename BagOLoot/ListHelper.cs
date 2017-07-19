using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ListHelper
    {
        
        private List<string> _children = new List<string>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ListHelper()
        {
            _connection = new SqliteConnection(_connectionString);
        }
        
        public List<string> GetChildren ()
        {
            // return new List<string>();
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Select the id and name of every child
                dbcmd.CommandText = $"select id, name from child";

                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    // read each row in the resultset
                    while (dr.Read())
                    {
                        _children.Add(dr[1].ToString()); //add child name to list
                    }
                }

                // clean up
                dbcmd.Dispose();
                _connection.Close();
            }
            return _children;
        }

        public List<string> GetOneToyList()
        {
            return new List<string>();
        }

        // public string GetChild (string name)
        // {
        //     var child = _children.SingleOrDefault(c => c == name);

        //     // Inevitably, two children will have the same name. Then what?

        //     return child;
        // }
    }
}