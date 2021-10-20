using IdeKortLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace IdeKortAPI.Manager
{
    public class Manager<T> : DbManager
    {
        private List<string> columnList;
      
        public Manager()
        {
            Start();
        }

        public async Task<List<T>> GetItemsAsync()
        {
            List<T> resultList = new List<T>();
            string SqlString = $"Select * from {typeof(T).Name}s";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string[] restrictions = new string[4] {null, null, "<TableName>", null};

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            resultList.Add(await ReadNext(reader));
                        }
                    }

                }
            }

            return resultList;
        }

        public async Task<T> GetItemById(int id)
        {
            string commandText = $"Select * FROM {typeof(T).Name}s WHERE Id = @Id";

            //var Item = default(T);
            var Item = default(T);
            Item = Activator.CreateInstance<T>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Item = await ReadNext(reader);
                        }
                    }
                }
            }

            return Item;
        }

        public async Task<T> CreateItem(T item)
        {
            //await SwitchIdentityInsertOption("ON", typeof(T).Name);
            var newItem = default(T);
            newItem = Activator.CreateInstance<T>();

            string commandText = $"INSERT INTO {typeof(T).Name}s VALUES (";
            string addTo;
            foreach (string s in columnList)
            {
                foreach (PropertyInfo t in item.GetType().GetProperties())
                {

                    if (s == t.Name && t.Name != "Id")
                    {

                        if (t.PropertyType == typeof(string))
                        {
                            addTo = $"'";
                            commandText = commandText + addTo;
                        }

                        if (t.PropertyType == typeof(bool))
                        {
                            if ((bool) t.GetValue(item, null))
                            {
                                addTo = $"1";
                            }
                            else
                            {
                                addTo = $"0";
                            }
                        } else if(t.PropertyType == typeof(DateTime))
                        {
                            addTo = $"convert(dateTime, '{t.GetValue(item, null)}')";
                        }
                        else
                        {
                            addTo = $"{t.GetValue(item, null)}";
                            
                        }
                        commandText = commandText + addTo;
                        if (t.PropertyType == typeof(string))
                        {
                            addTo = $"'";
                            commandText = commandText + addTo;
                        }
                    }

                }

                if (s != "Id")
                {
                    addTo = $",";
                    commandText = commandText + addTo;
                }
                
            }

            commandText = commandText.Remove(commandText.Length - 1);
            addTo = ")";
            commandText = commandText + addTo;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    try
                    {
                        cmd.ExecuteScalar();
                        newItem = await GetLastId();
                        //await SwitchIdentityInsertOption("OFF", typeof(T).Name);
                    }
                    catch (Exception e)
                    {
                        return default(T);

                    }
                }
            }

            return newItem;
        }

        public async Task<bool> DeleteItemsById(int id)
        {
            bool Success = false;

            string commandText = $"DELETE FROM {typeof(T).Name}s WHERE Id = @ID";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            Success = true;
                        }
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }

            return Success;
        }

        public async Task<T> UpdateItemsById(T item)
        {
            var newItem = default(T);
            newItem = Activator.CreateInstance<T>();

            string commandText = $"UPDATE {typeof(T).Name}s SET ";
            string addTo;
            int id = 0;
            foreach (string s in columnList)
            {
                if (s !="Id")
                {
                    addTo = $"{s} = ";
                    commandText = commandText + addTo;
                }
                
                foreach (PropertyInfo t in item.GetType().GetProperties())
                {
                    if (t.Name == "Id")
                    {
                        id = (int) t.GetValue(item, null);
                    }
                    if (s == t.Name && t.Name != "Id")
                    {

                        if (t.PropertyType == typeof(string))
                        {
                            addTo = $"'";
                            commandText = commandText + addTo;
                        }

                        if (t.PropertyType == typeof(bool))
                        {
                            if ((bool)t.GetValue(item, null))
                            {
                                addTo = $"1";
                            }
                            else
                            {
                                addTo = $"0";
                            }
                        }
                        else if (t.PropertyType == typeof(DateTime))
                        {
                            addTo = $"convert(dateTime, '{t.GetValue(item, null)}')";
                        }
                        else
                        {
                            addTo = $"{t.GetValue(item, null)}";

                        }
                        commandText = commandText + addTo;
                        if (t.PropertyType == typeof(string))
                        {
                            addTo = $"'";
                            commandText = commandText + addTo;
                        }
                    }

                }

                if (s != "Id")
                {
                    addTo = $",";
                    commandText = commandText + addTo;
                }

            }

            commandText = commandText.Remove(commandText.Length - 1);
            addTo = $" WHERE Id = {id}";
            commandText = commandText + addTo;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    try
                    {
                        cmd.ExecuteScalar();
                        newItem = await GetLastId();
                    }
                    catch (Exception e)
                    {
                        return default(T);

                    }
                }
            }

            return newItem;
        }

        public async Task<List<string>> GetColumnNames()
        {
            List<string> resultList = new List<string>();
            string SqlString =
                $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{typeof(T).Name}s'";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string[] restrictions = new string[4] {null, null, "<TableName>", null};

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            resultList.Add(reader.GetString(0));
                        }
                    }

                }
            }

            return resultList;
        }

        private async Task<T> ReadNext(SqlDataReader reader)
        {

            var item = default(T); //Create item of type T
            item = Activator.CreateInstance<T>(); //Create instance of class T like new()

            for (int i = 0; i < columnList.Count; i++) //Runs code for each column in table
            {
                System.Reflection.PropertyInfo[]
                    properties = item.GetType().GetProperties(); //Gets properties from class
                for (int a = 0; a < properties.Length; a++) //Runs code for each properties in class
                {
                    string propertyName =
                        item.GetType().GetProperties()[a].Name; //Gets the name from property (like Id)
                    if (propertyName == columnList[i]) //Compares property name from class and sql
                    {
                        TrySetProperty(item, propertyName, reader[propertyName]);
                    } 
                }
            }

            return item;
        }

        private bool TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite && value != DBNull.Value)
            {
                prop.SetValue(obj, value, null);
                return true;
            }

            return false;
        }

        private async void Start()
        {
            columnList = await GetColumnNames(); //Gets all columnnames from sql table
        }

        private async Task SwitchIdentityInsertOption(string set, string table)
        {
            string commandText = $"SET IDENTITY_INSERT {table}s {set}";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }

        private async Task<T> GetLastId()
        {
            List<T> result = await GetItemsAsync();
            return result.Last();
        }

        //public async Task<List<T>> ItemWithClasses(List<T> a)
        //{
        //    List<T> result = new List<T>();
        //    foreach (T o in a)
        //    {
        //        result.Add(await ItemWithClasses(o));
        //    }

        //    return result;
        //}

        //public async Task<T> ItemWithClasses(T o)
        //{
        //    var newItem = default(T);
        //    newItem = Activator.CreateInstance<T>();
        //    foreach (PropertyInfo prop in o.GetType().GetProperties())
        //    {
        //        if (prop.Name.Contains("Class"))
        //        {
        //            string classname = prop.Name.Remove(prop.Name.Length - 5);
        //            if (prop.Name == "CompanyClass")
        //            {
        //                classname = "User";
        //            }
        //            foreach (PropertyInfo prop2 in o.GetType().GetProperties())
        //            {
        //                if (prop2.Name == classname)
        //                {
        //                    if (classname == "Role")
        //                    {
        //                        Manager<Role> mgr = new Manager<Role>();
        //                        TrySetProperty(newItem, prop.Name, await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    } else if (classname == "Address")
        //                    {
        //                        Manager<Address> mgr = new Manager<Address>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int) prop2.GetValue(o, null)));
        //                    } else if (classname == "Active")
        //                    {
        //                        Manager<Active> mgr = new Manager<Active>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    } else if(classname == "Customer") 
        //                    {
        //                        Manager<Customer> mgr = new Manager<Customer>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    } else if (classname == "Company")
        //                    {
        //                        Manager<Company> mgr = new Manager<Company>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    } else if (classname == "Amount")
        //                    {
        //                        Manager<Amount> mgr = new Manager<Amount>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    } else if (classname == "Chip")
        //                    {
        //                        Manager<Chip> mgr = new Manager<Chip>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    } else if (classname == "Event")
        //                    {
        //                        Manager<Event> mgr = new Manager<Event>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    }
        //                    else if (classname == "Product")
        //                    {
        //                        Manager<Product> mgr = new Manager<Product>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    } else if (classname == "Transaction")
        //                    {
        //                        Manager<Transaction> mgr = new Manager<Transaction>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    } else if (classname == "User")
        //                    {
        //                        Manager<User> mgr = new Manager<User>();
        //                        TrySetProperty(newItem, prop.Name,
        //                            await mgr.GetItemById((int)prop2.GetValue(o, null)));
        //                    }
                            
        //                }
        //            }
        //        }
        //        else
        //        {
        //            TrySetProperty(newItem, prop.Name, prop.GetValue(o, null));
        //        }
        //    }
        //    return newItem;
        //}
    }
}
