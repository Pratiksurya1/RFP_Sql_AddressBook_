﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AddressBookADO.NET
{
    public class DBHandler : DBConnector
    {
        public override void Insert(AddressBookModel model)
        {
            SqlConnection connection = GetDBConnection();
            try
            {
                if (model != null)
                {
                    using (connection)
                    {
                        SqlCommand command = new SqlCommand("AddressBookProcedure", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("stmnt", "Insert");
                        command.Parameters.AddWithValue("firstName", model.firstName);
                        command.Parameters.AddWithValue("lastName", model.lastName);
                        command.Parameters.AddWithValue("address", model.address);
                        command.Parameters.AddWithValue("city", model.city);
                        command.Parameters.AddWithValue("state", model.state);
                        command.Parameters.AddWithValue("zip", model.zip);
                        command.Parameters.AddWithValue("mobileNo", model.mobileNo);
                        command.Parameters.AddWithValue("email", model.email);
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Data Inserted Successfully");
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Inserted ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public override void Update(AddressBookModel model, String position)
        {
            SqlConnection connection = GetDBConnection();
            try
            {
                if (model != null)
                {
                    using (connection)
                    {
                        SqlCommand command = new SqlCommand("AddressBookProcedure", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("stmnt", "Update");
                        command.Parameters.AddWithValue("position", position);
                        command.Parameters.AddWithValue("firstName", model.firstName);
                        command.Parameters.AddWithValue("lastName", model.lastName);
                        command.Parameters.AddWithValue("address", model.address);
                        command.Parameters.AddWithValue("city", model.city);
                        command.Parameters.AddWithValue("state", model.state);
                        command.Parameters.AddWithValue("zip", model.zip);
                        command.Parameters.AddWithValue("mobileNo", model.mobileNo);
                        command.Parameters.AddWithValue("email", model.email);

                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Data Update Successfully");
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Inserted ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public override void Delete(string position)
        {
            SqlConnection connection = GetDBConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("AddressBookProcedure", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("stmnt", "Delete");
                    command.Parameters.AddWithValue("position", position);
                    connection.Open();
                    Console.WriteLine("Data Delete Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public override void SelectByCityORState(String location)
        {
            SqlConnection connection = GetDBConnection();
            try
            {
                using (connection)
                {
                    AddressBookModel model = new AddressBookModel();
                    SqlCommand command = new SqlCommand("AddressBookProcedure", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("city", location);
                    command.Parameters.AddWithValue("state", location);
                    command.Parameters.AddWithValue("stmnt", "Select");
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int n = reader.GetInt32(0);
                            model.firstName = reader[1].ToString();
                            model.lastName = reader[2].ToString();
                            model.address = reader[3].ToString();
                            model.city = reader[4].ToString();
                            model.state = reader[5].ToString();
                            model.zip = reader[6].ToString();
                            model.mobileNo = reader[7].ToString();
                            model.email = reader[8].ToString();

                            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found..");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public override void SelectCountByCountryORState()
        {
            SqlConnection connection = GetDBConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("AddressBookProcedure", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("stmnt", "count");
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["city"] + "\t" + reader["citycount"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public override void SortByCityORState(string location)
        {
            SqlConnection connection = GetDBConnection();
            try
            {
                using (connection)
                {
                    AddressBookModel model = new AddressBookModel();
                    SqlCommand command = new SqlCommand("AddressBookProcedure", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("city", location);
                    command.Parameters.AddWithValue("state", location);
                    command.Parameters.AddWithValue("stmnt", "Sortasc");
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            count++;
                            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString());
                        }
                        Console.WriteLine(count + " Person From " + location);
                    }
                    else
                    {
                        Console.WriteLine("No Data Found..");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public override void AddMultpleContact(params AddressBookModel[] models)
        {           
            foreach(AddressBookModel model in models)
            {
                Insert(model);
            }
        }
        public void AddBookName(String BookName)
        {
            SqlConnection connection = GetDBConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("insert into AddressBook values (" +BookName+ ")", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book name is add");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FileWriter()
        {
            String path = "D:/.Net/C#/AddressBookADO.NET.ContactInto.txt";
            SqlConnection connection = GetDBConnection();
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("Select * from contact_info", connection);
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(); 

                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        foreach (SqlDataReader info in reader)
                        {                          
                            sw.WriteLine(info["book_Id"] + "\t" + info["contact_Id"] + "\t" + info["firstName"] + "\t" + info["lastName"] + "\t" + info["address"] + "\t" + info["city"] + "\t" + info["state"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void JsonWriter()
        {
            SqlConnection connection = GetDBConnection();

            Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
            using (StreamWriter writer = new StreamWriter(@"D:\.Net\C#\AddressBookADO.NET\JsonFile.json"))
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))

            using (connection)
            {
                List<String> list = new List<String>();
                SqlCommand command = new SqlCommand("Select * from contact_info",connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                
                SqlDataReader reader = command.ExecuteReader();
                list.Add((string)reader["book_Id"]);
                list.Add((string)reader["contact_Id"]);
                list.Add((string)reader["firstName"]);
                list.Add((string)reader["lastName"]);
                list.Add((string)reader["address"]);
                list.Add((string)reader["city"]);
                list.Add((string)reader["state"]);
                list.Add((string)reader["zip"]);
                list.Add((string)reader["email"]);
                list.Add((string)reader["mobileNo"]);
                Console.WriteLine(list);
                {
                    foreach (var info in list)
                    {
                        jsonSerializer.Serialize(jsonWriter, list);
                    }
                }
            }
        }
    }
}
