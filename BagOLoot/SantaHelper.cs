using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
// using System.Collections.Generic;

namespace BagOLoot
{
    public class SantaHelper
    {

        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;
        public SantaHelper()
        {
            _connection = new SqliteConnection(_connectionString);
        }
        public int AddToyToBag(string toy, int childId)
        {
            // Returns the new toy ID
            int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new child
                dbcmd.CommandText = $"insert into toy values (null, '{toy}', {childId})";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();

                // Get the id of the new row
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        _lastId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _lastId;
        }

        public int RemoveToyFromBag(int toyId, int childId)
        {
            // returns childId
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new child
                dbcmd.CommandText = $"delete from toy where id = {toyId}";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }
            return childId;
        }
        public int MarkAsDelivered(int childId)
        {
            // returns boolean
            int boo = 0;
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new child
                dbcmd.CommandText = $"UPDATE child SET delivered = 1 WHERE id = {childId}";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();

                // Get the id of the new row
                dbcmd.CommandText = $"select delivered from child where id={childId}";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        boo = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return boo;
        }

        public void ListChildrenOnConsole (Dictionary<int, string> childrenList)
        {
            int c = 0;
            foreach (KeyValuePair<int, string> thing in childrenList)
            {
                c++;
                Console.WriteLine($"{c}. {thing.Value}");
            }
        }

        public int AcceptChosenChild(Dictionary<int, string> childrenList)
        {
            Console.Write ("> ");
            int assignedChild;
            Int32.TryParse (Console.ReadLine(), out assignedChild);
            int x = 0;
            foreach (KeyValuePair<int, string> thing in childrenList)
            {
                x++;
                if (x == assignedChild)
                {
                    assignedChild = thing.Key;
                }
            }
            return assignedChild;
        }   

        public int ListAndAcceptChildren(Dictionary<int, string> childrenList, SantaHelper Helper)
        {
            int assignedChild;
            Helper.ListChildrenOnConsole(childrenList);
            assignedChild = Helper.AcceptChosenChild(childrenList);
            return assignedChild;
        }     

    }
}