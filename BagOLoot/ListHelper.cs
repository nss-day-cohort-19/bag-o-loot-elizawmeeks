using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ListHelper
    {
        
        private Dictionary<int, string> _children = new Dictionary<int, string>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ListHelper()
        {
            _connection = new SqliteConnection(_connectionString);
        }
        
        public Dictionary<int, string> GetChildren ()
        {
            // return new Dictionary<int, string>();
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
                        int result;
                        Int32.TryParse(dr[0].ToString(), out result);
                        _children.Add(result, dr[1].ToString()); //add child name to list
                    }
                }

                // clean up
                dbcmd.Dispose();
                _connection.Close();
            }
            return _children;
        }

        public List<string> GetChildsToys(int childId)
        {
            // Returns list of toy names for this child
            List<string> ToyList = new List<string>();
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Select the id and name of every child
                dbcmd.CommandText = $"select name from toy where childId = {childId}";

                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    // read each row in the resultset
                    while (dr.Read())
                    {
                        ToyList.Add(dr[0].ToString()); //add toyId to list
                    }
                }

                // clean up
                dbcmd.Dispose();
                _connection.Close();
            }
            return ToyList;
        }

        public List<int> GetChildsToyIds(int childId)
        {
            // Returns list of toy Ids for this child
            List<int> ToyIdList = new List<int>();
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Select the id and name of every child
                dbcmd.CommandText = $"select id from toy";

                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    // read each row in the resultset
                    while (dr.Read())
                    {
                        int result;
                        Int32.TryParse(dr.ToString(), out result);
                        ToyIdList.Add(result); //add toyId to list
                    }
                }

                // clean up
                dbcmd.Dispose();
                _connection.Close();
            }
            return ToyIdList;
        }

        // public string GetChild (string name)
        // {
        //     var child = _children.SingleOrDefault(c => c == name);

        //     // Inevitably, two children will have the same name. Then what?

        //     return child;
        // }
    }
}